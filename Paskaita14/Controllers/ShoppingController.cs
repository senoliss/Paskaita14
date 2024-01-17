using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paskaita14.BussinessLayer;
using Paskaita14.Models;

namespace Paskaita14.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoppingController : ControllerBase
	{
		private readonly IShoppingListService _shoppingListService;
		public ShoppingController(IShoppingListService shoppingListService)
		{
			_shoppingListService = shoppingListService;
		}

		[HttpGet]
		public IActionResult GetAllShoppingList(int userId)
		{
			var shoppingLists = _shoppingListService.GetUserShoppingList(userId);
			return Ok(shoppingLists);
		}

		[HttpGet]
		[Route("{id}")]
		public IActionResult GetShoppingListById(int id, int userId)
		{
			var shoppingList = _shoppingListService.GetShoppingForUserListById(id, userId);
			return Ok(shoppingList);
		}

		[HttpPost]
		public IActionResult CreateShoppingList(ShoppingList shoppingList)
		{
			var shoppingListId = _shoppingListService.CreateShoppingList(shoppingList);
			return Ok(shoppingListId);
		}

		[HttpPut]
		public IActionResult UpdateShoppingList(ShoppingList shoppingList, int userId)
		{
			_shoppingListService.UpdateShoppingList(shoppingList, userId);
			return Ok("Shopping List was created");
		}

		[HttpDelete]
		public IActionResult DeleteShoppingList(int id, int userId)
		{
			_shoppingListService.DeleteShoppingList(id, userId);
			return Ok("Shopping List was deleted");
		}

	}
}
