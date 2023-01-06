using backend_api.Database;
using backend_api.Models.Requests;
using backend_api.Models.Tables.UserData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace backend_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    [SwaggerTag("Средства работы с данными пользователей")]
    public class UserController : Controller
    {
        private readonly UnitripAPIDbContext dbContext;
        public UserController(UnitripAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("all")]
        [Description("Возвращает список всех пользователей")]
        [SwaggerOperation("GetAllUsers", Summary = "Возвращает список всех пользователей")]
        [SwaggerResponse(200, "Возвращает список всех пользователей", typeof(List<User>))]
        [SwaggerResponse(400, "Ошибка при получении списка пользователей")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }

        [HttpGet("guid")]
        [Description("Возвращает всю информацию о пользователе по его уникальному идентификатору")]
        [SwaggerResponse(200, "Возвращает информацию о пользователе по его уникальному идентификатору", typeof(User))]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByGuid([FromBody] UserGuidRequest userGuidRequest)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == userGuidRequest.UserGuid);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("id")]
        [Description("Возвращает информацию о пользователе по его идентификатору")]
        [SwaggerResponse(200, "Возвращает информацию о пользователе по его идентификатору", typeof(UserGet))]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserById([FromBody] UserIdRequest userIdRequest)
        {
            var userMeta = await dbContext.UserMetas.FirstOrDefaultAsync(u => u.UserId == userIdRequest.Id);
            if (userMeta == null)
            {
                return NotFound();
            }
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == userMeta.UserGuid);

            var userGet = new UserGet
            {
                UserGuid = user.Guid,
                Id = userMeta.UserId,
                Email = user.Email,
                IsActive = user.IsActive,
                IsReported = user.IsReported,
                IsBanned = user.IsBanned,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

            return Ok(userGet);
        }

        [HttpGet("email")]
        [Description("Возвращает информацию о пользователе по его электронной почте")]
        [SwaggerResponse(200, "Возвращает информацию о пользователе по его электронной почте", typeof(UserGet))]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByEmail([FromBody] UserEmailRequest userEmailRequest)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmailRequest.Email);

            if (user == null)
            {
                return NotFound();
            }

            var userMeta = await dbContext.UserMetas.FirstOrDefaultAsync(u => u.UserGuid == user.Guid);

            var userGet = new UserGet
            {
                UserGuid = user.Guid,
                Id = userMeta.UserId,
                Email = user.Email,
                IsActive = user.IsActive,
                IsReported = user.IsReported,
                IsBanned = user.IsBanned,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

            return Ok(userGet);
        }

        [HttpGet("username")]
        [Description("Возвращает информацию о пользователе по его имени пользователя")]
        [SwaggerResponse(200, "Возвращает информацию о пользователе по его имени пользователя", typeof(UserGet))]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByUsername([FromBody] UserNicknameRequest userNicknameRequest)
        {
            var userMeta = await dbContext.UserMetas.FirstOrDefaultAsync(u => u.Nickname == userNicknameRequest.Nickname);
            if (userMeta == null)
            {
                return NotFound();
            }
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == userMeta.UserGuid);

            var userGet = new UserGet
            {
                UserGuid = user.Guid,
                Id = userMeta.UserId,
                Email = user.Email,
                IsActive = user.IsActive,
                IsReported = user.IsReported,
                IsBanned = user.IsBanned,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

            return Ok(userGet);
        }

        [HttpGet("activity")]
        [Description("Возвращает информацию об активности пользователя по его идентификатору")]
        [SwaggerResponse(200, "Возвращает информацию об активности пользователя по его идентификатору", typeof(UserIdRequest))]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserActivityById([FromBody] UserIdRequest userIdRequest)
        {
            var userMeta = await dbContext.UserMetas.FirstOrDefaultAsync(u => u.UserId == userIdRequest.Id);
            if (userMeta == null)
            {
                return NotFound();
            }
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == userMeta.UserGuid);

            var userGetAllActivity = new 
            {
                PostCount = await dbContext.Posts.CountAsync(p => p.UserGuid == user.Guid),
                CommentCount = await dbContext.Comments.CountAsync(c => c.UserGuid == user.Guid),
            };

            return Ok(userGetAllActivity);
        }

        [HttpGet("search")]
        [Description("Возвращает информацию о пользователях по заданным параметрам")]
        [SwaggerResponse(200, "Возвращает информацию о пользователях по заданным параметрам", typeof(List<UserGet>))]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> SearchUsers([FromQuery] UserSearch userSearch)
        {
            var users = await dbContext.Users
                .Where(u => u.FirstName.Contains(userSearch.FirstName) && u.LastName.Contains(userSearch.LastName))
                .ToListAsync();

            var userMetas = await dbContext.UserMetas
                .Where(u => u.Nickname.Contains(userSearch.Nickname))
                .ToListAsync();

            var userGets = new List<UserGet>();

            foreach (var user in users)
            {
                var userMeta = userMetas.FirstOrDefault(u => u.UserGuid == user.Guid);

                var userGet = new UserGet
                {
                    UserGuid = user.Guid,
                    Id = userMeta.UserId,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    IsReported = user.IsReported,
                    IsBanned = user.IsBanned,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt
                };

                userGets.Add(userGet);
            }

            return Ok(userGets);
        }

        [HttpPost("create")]
        [Description("Создает нового пользователя")]
        [SwaggerResponse(200, "Создает нового пользователя", typeof(User))]
        [SwaggerResponse(400, "Некорректные данные")]
        [SwaggerResponse(409, "Пользователь с таким именем пользователя уже существует")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var user = new User
            {
                Guid = Guid.NewGuid(),
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IsActive = true,
                IsReported = false,
                IsBanned = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("update")]
        [Description("Обновляет информацию о пользователе")]
        [SwaggerResponse(200, "Обновляет информацию о пользователе", typeof(User))]
        [SwaggerResponse(400, "Некорректные данные")]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == request.UserGuid);
            if (user == null)
            {
                return NotFound();
            }

            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UpdatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPatch("update/password")]
        [Description("Обновляет пароль пользователя")]
        [SwaggerResponse(200, "Обновляет пароль пользователя", typeof(MessageResponse))]
        [SwaggerResponse(400, "Некорректные данные")]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdateUserPasswordRequest request)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == request.UserGuid);
            if (user == null)
            {
                return NotFound();
            }

            if (user.Password != request.Password)
            {
                return BadRequest();
            }

            user.Password = request.NewPassword;
            user.UpdatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return Ok("Пароль успешно изменен");
        }

        [HttpPatch("update/active")]
        [Description("Обновляет статус активности пользователя")]
        [SwaggerResponse(200, "Обновляет статус активности пользователя", typeof(MessageResponse))]
        [SwaggerResponse(400, "Некорректные данные")]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUserActive([FromBody] UpdateUserActiveRequest request)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == request.UserGuid);
            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = request.IsActive;
            user.UpdatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return Ok("Статус активности успешно изменен");
        }

        [HttpPatch("update/status")]
        [Description("Обновляет статус пользователя")]
        [SwaggerResponse(200, "Обновляет статус пользователя", typeof(MessageResponse))]
        [SwaggerResponse(400, "Некорректные данные")]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateUserStatus([FromBody] UpdateUserStatusRequest request)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == request.UserGuid);
            if (user == null)
            {
                return NotFound();
            }

            user.IsReported = request.Status == "reported";
            user.IsBanned = request.Status == "banned";
            user.UpdatedAt = DateTime.Now;

            await dbContext.SaveChangesAsync();

            return Ok("Статус пользователя успешно изменен");
        }

        [HttpDelete("delete")]
        [Description("Удаляет пользователя")]
        [SwaggerResponse(200, "Удаляет пользователя", typeof(MessageResponse))]
        [SwaggerResponse(400, "Некорректные данные")]
        [SwaggerResponse(404, "Пользователь не найден")]
        [SwaggerResponse(500, "Ошибка сервера")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Guid == request.UserGuid);
            if (user == null)
            {
                return NotFound();
            }
            if (user.Password != request.Password || user.Email != request.Email)
            {
                return BadRequest();
            }

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return Ok("Пользователь успешно удален");
        }

    }
}
