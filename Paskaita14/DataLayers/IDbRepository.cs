using Paskaita14.Models;

namespace Paskaita14.DataLayers
{
	public interface IDbRepository
	{
		int CreateShoppingList(ShoppingList shoppingList);
		ShoppingList GetShoppingListById(int id);
		List<ShoppingList> GetShoppingListByUserId(int userId);
		void UpdateShoppingList(ShoppingList shoppingList);
		void DeleteShoppingList(int id);
	}
}
