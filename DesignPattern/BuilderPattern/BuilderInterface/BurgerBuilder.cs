using Common.Contracts.Burger;

namespace BuilderPattern.BuilderInterface
{
    public abstract class BurgerBuilder<T> : GenericBuilder<T> where T : IBurger
    {
        public BurgerBuilder<T> SetId(string id)
        {
            target.Id = id;
            return this;
        }
        public BurgerBuilder<T> SetBurgerCode(string BurgerCode)
        {
            target.BurgerCode = BurgerCode;
            return this;
        }
        public BurgerBuilder<T> SetBun(string bun)
        {
            target.Bun = bun;
            return this;
        }
        public BurgerBuilder<T> SetCreateDate(DateTime createDate)
        {
            target.CreateDate = createDate;
            return this;
        }
    }
}
