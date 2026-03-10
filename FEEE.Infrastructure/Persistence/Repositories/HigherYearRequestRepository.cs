using FEEE.Application.DTOs.HigherYearRequests;
using FEEE.Application.Interfaces;
using FEEE.Domain.Entities;
using FEEE.Domain.Enums;
using FEEE.Infrastructure.Persistence.Context;
using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

public class HigherYearRequestRepository : IHigherYearRequestRepository
{
    private readonly AppDbContext _context;

    public HigherYearRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> HasPendingRequestAsync(int studentId)
    {
        return await _context.HigherYearRequests
            .AnyAsync(x => x.StudentId == studentId && x.Status == HigherYearRequestStatus.Pending);
    }

    public async Task<int> CreateAsync(HigherYearRequestModel request)
    {
        var entity = new HigherYearRequest
        {
            StudentId = request.StudentId,
            YearId = request.YearId,
            SectionId = request.SectionId,
            SemesterId = request.SemesterId,
            CreatedAt = request.CreatedAt,
            Status = request.Status
        };

        _context.HigherYearRequests.Add(entity);
        await _context.SaveChangesAsync();

        var links = request.SubjectIds.Select(subjectId => new HigherYearRequestSubject
        {
            RequestId = entity.Id,
            SubjectId = subjectId
        });

        _context.HigherYearRequestSubjects.AddRange(links);
        await _context.SaveChangesAsync();

        return entity.Id;
    }
    public async Task<List<HigherYearRequestListItemDto>> GetAllAsync()
    {
        return await _context.HigherYearRequests
            .AsNoTracking()
            .Include(x => x.Student)
            .Include(x => x.Section)
            .Include(x => x.Year)
            .Include(x => x.Semester)
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new HigherYearRequestListItemDto
            {
                RequestId = x.Id,
                StudentName = (x.Student.FirstName + " " + x.Student.LastName).Trim(),
                UniversityNumber = x.Student.UniversityNumber,
                Section = x.Section.Name,
                Year = x.Year.Name,
                Status = x.Status.ToString().ToUpper(),
                RequestDate = x.CreatedAt.Date,
                Semester = x.Semester.Name
            })
            .ToListAsync();
    }
    public async Task<HigherYearRequestDetailsDto?> GetByIdAsync(int requestId)
    {
        var request = await _context.HigherYearRequests
        .AsNoTracking()
        .Include(x => x.Student)
        .Include(x => x.Section)
        .Include(x => x.Year)
        .Include(x => x.Semester)
        .Include(x => x.HigherYearRequestSubjects)
            .ThenInclude(link => link.Subject)
        .FirstOrDefaultAsync(x => x.Id == requestId);

        if (request == null) return null;

        var selectedSubjects = request.HigherYearRequestSubjects
            .Select(x => new SubjectDto { Id = x.SubjectId, Name = x.Subject.Name })
            .ToList();

        return new HigherYearRequestDetailsDto
        {
            RequestId = request.Id,
            RequestDate = request.CreatedAt.Date,
            Status = request.Status.ToString().ToUpper(),

            Student = new StudentInfoDto
            {
                FullName = (request.Student.FirstName + " " + request.Student.LastName).Trim(),
                UniversityNumber = request.Student.UniversityNumber,
                BirthDate = request.Student.BirthDate
            },

            Section = new LookupDto { Id = request.SectionId, Name = request.Section.Name },
            Year = new LookupDto { Id = request.YearId, Name = request.Year.Name },
            Semester = new LookupDto { Id = request.SemesterId, Name = request.Semester.Name },

            SelectedSubjects = selectedSubjects
        };
    }
    public async Task<HigherYearRequestModel?> GetByIdForUpdateAsync(int id)
    {
        var entity = await _context.HigherYearRequests
            .AsNoTracking()
            .Include(r => r.HigherYearRequestSubjects) // جدول الربط تبع المواد
            .FirstOrDefaultAsync(r => r.Id == id);

        if (entity == null) return null;

        return new HigherYearRequestModel
        {
            Id = entity.Id,
            StudentId = entity.StudentId,
            YearId = entity.YearId,
            SectionId = entity.SectionId,
            SemesterId = entity.SemesterId,

            // حسب عندك ستاتس مخزن byte أو int
            Status = (HigherYearRequestStatus)(entity.Status),

            // تحويل جدول الربط لقائمة IDs
            SubjectIds = entity.HigherYearRequestSubjects
                .Select(x => x.SubjectId)
                .Distinct()
                .ToList()
        };
    }

    public async Task<bool> UpdateAsync(HigherYearRequestModel model)
    {
        var entity = await _context.HigherYearRequests
            .Include(r => r.HigherYearRequestSubjects)
            .FirstOrDefaultAsync(r => r.Id == model.Id);

        if (entity == null) return false;

        // تحديث الحقول الأساسية
        entity.YearId = model.YearId;
        entity.SectionId = model.SectionId;
        entity.SemesterId = model.SemesterId;

        // ⚠️ خليه byte/int حسب عمود الداتابيز عندك
        entity.Status = model.Status;

        // تحديث المواد: أسهل شي "replace"
        var newIds = (model.SubjectIds ?? new List<int>()).Distinct().ToHashSet();

        // احذف اللي مو موجود
        var toRemove = entity.HigherYearRequestSubjects
        .Where(x => !newIds.Contains(x.SubjectId))
        .ToList();

        foreach (var item in toRemove)
            entity.HigherYearRequestSubjects.Remove(item);


        // ضيف الجديد
        var existingIds = entity.HigherYearRequestSubjects.Select(x => x.SubjectId).ToHashSet();
        foreach (var sid in newIds)
        {
            if (existingIds.Contains(sid)) continue;

            entity.HigherYearRequestSubjects.Add(new HigherYearRequestSubject
            {
                RequestId = entity.Id,
                SubjectId = sid
            });
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CancelAsync(int id)
    {
        var entity = await _context.HigherYearRequests
            .Include(r => r.HigherYearRequestSubjects)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (entity == null) return false;

        // deleting the related HigherYearRequestSubjects
        _context.HigherYearRequestSubjects.RemoveRange(entity.HigherYearRequestSubjects);

        _context.HigherYearRequests.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<HigherYearRequestListItemDto>> GetListAsync(
    HigherYearRequestFilterDto filter)
    {
        var query = _context.HigherYearRequests
            .Include(x => x.Student)
            .Include(x => x.Section)
            .Include(x => x.Year)
            .Include(x => x.Semester)
            .AsQueryable();

        if (filter.SectionId.HasValue)
            query = query.Where(x => x.SectionId == filter.SectionId).OrderBy(x=> x.SectionId);

        if (filter.YearId.HasValue)
            query = query.Where(x => x.YearId == filter.YearId).OrderBy(x=> x.YearId);

        if (filter.Status.HasValue)
            query = query.Where(x => x.Status == filter.Status.Value).OrderBy(x=>x.Status);

        if (!string.IsNullOrEmpty(filter.StudentName))
            query = query.Where(x =>
                (x.Student.FirstName + " " + x.Student.LastName)
                .Contains(filter.StudentName))
                .OrderBy(x => x.Student.FirstName)
                .ThenBy(x => x.Student.LastName);

        if (!string.IsNullOrEmpty(filter.UniversityNumber))
            query = query.Where(x =>
                x.Student.UniversityNumber.Contains(filter.UniversityNumber))
                .OrderBy(x => x.Student.UniversityNumber);

        if (filter.FromDate.HasValue)
        {
            var from = filter.FromDate.Value.Date;
            query = query.Where(x => x.CreatedAt >= from);
        }

        if (filter.ToDate.HasValue)
        {
            var to = filter.ToDate.Value.Date.AddDays(1);
            query = query.Where(x => x.CreatedAt < to);
        }

        if (filter.Date.HasValue)
        {
            var dayStart = filter.Date.Value.Date;
            var dayEnd = dayStart.AddDays(1);

            query = query.Where(x =>
                x.CreatedAt >= dayStart &&
                x.CreatedAt < dayEnd
            );
        }

       

        return await query
            .Select(x => new HigherYearRequestListItemDto
            {
                RequestId = x.Id,
                StudentName = x.Student.FirstName + " " + x.Student.LastName,
                UniversityNumber = x.Student.UniversityNumber,
                Section = x.Section.Name,
                Year = x.Year.Name,
                Status = x.Status.ToString(),
                RequestDate = x.CreatedAt,
                Date = x.CreatedAt.Date,
                Semester = x.Semester.Name

            })
            .ToListAsync();
    }


}
