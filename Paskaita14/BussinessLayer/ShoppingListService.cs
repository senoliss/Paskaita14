using Paskaita14.DataLayers;
using Paskaita14.Models;

namespace Paskaita14.BussinessLayer
{
	public class ShoppingListService : IShoppingListService
	{
        private readonly IDbRepository _dbRepository;
        public ShoppingListService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public int CreateShoppingList(ShoppingList shoppingList)
        {
            return _dbRepository.CreateShoppingList(shoppingList);
        }

        public void DeleteShoppingList(int id, int userId)
        {
            var shoppingList = _dbRepository.GetShoppingListById(id);
            if(shoppingList == null)
            {
                throw new Exception("List not found!");
            }
            if(shoppingList.UserId != userId)
            {
                throw new Exception("User is trying to delete foreign list!");
            }

            _dbRepository.DeleteShoppingList(id);
        }

        public void UpdateShoppingList(ShoppingList shoppingList, int userId)
        {
            if(shoppingList.UserId != userId)
            {
                throw new Exception("User cannot update foreign shopping list!");
            }
            _dbRepository.UpdateShoppingList(shoppingList);
        }

		public ShoppingList GetShoppingForUserListById(int id, int userId)
        {
            var shoppingList = _dbRepository.GetShoppingListById(id);
            if(shoppingList == null)
            {
                throw new Exception("Shopping list not found!");
            }
            if(shoppingList.UserId != userId)
            {
                throw new Exception("User is trying to get foreign list!");
            }

            return shoppingList;
        }
		public List<ShoppingList> GetUserShoppingList(int userId)
        {
            return _dbRepository.GetShoppingListByUserId(userId);
        }
	}
}
