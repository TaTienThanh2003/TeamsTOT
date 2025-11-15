using backTOT.Data;
using backTOT.Entities;
using backTOT.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backTOT.Controllers
{
    [ApiController]
    [Route("api")]
    public class PermissionController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly IPermissionCache _permissionCache;

        public PermissionController(DataContext db, IPermissionCache permissionCache)
        {
            _db = db;
            _permissionCache = permissionCache;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddPermission([FromBody] Permission model)
        {
            _db.Permissions.Add(model);
            await _db.SaveChangesAsync();

            _permissionCache.Refresh(); // 🟢 Làm mới cache ngay

            return Ok(new { message = "Đã thêm quyền và làm mới cache" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(Guid id)
        {
            var perm = await _db.Permissions.FindAsync(id);
            if (perm == null) return NotFound();

            _db.Permissions.Remove(perm);
            await _db.SaveChangesAsync();

            _permissionCache.Refresh(); // 🟢 Làm mới cache ngay

            return Ok(new { message = "Đã xóa quyền và làm mới cache" });
        }
    }
}
