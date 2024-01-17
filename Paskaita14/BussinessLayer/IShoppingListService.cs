using Paskaita14.DataLayers;
using Paskaita14.Models;

namespace Paskaita14.BussinessLayer
{
	public interface IShoppingListService
	{
		/// <summary>
		/// Inserts shopping list to database
		/// </summary>
		/// <param name="shoppingList"></param>
		/// <returns>Insert shopping list ID</returns>
		int CreateShoppingList(ShoppingList shoppingList);
		ShoppingList GetShoppingForUserListById(int id, int userId);
		List<ShoppingList> GetUserShoppingList(int userId);
		void UpdateShoppingList(ShoppingList shoppingList, int userId);
		void DeleteShoppingList(int id, int userId);
	}
}
