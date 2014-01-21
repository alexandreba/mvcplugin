using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NInjectByHand
{
    public interface IWeapon
    {
        void Hit(string target);
    }

    class Sword : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Chopped {0} clean in half", target);
        }
    }

    public class Shuriken : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Pierced {0}'s armor", target);
        }
    }

    public class Samurai
    {
        readonly IWeapon weapon;
        public Samurai(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void Attack(string target)
        {
            this.weapon.Hit(target);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region DI by hand
            //var warrior1 = new Samurai(new Shuriken());
            //var warrior2 = new Samurai(new Sword());
            //warrior1.Attack("the evildoers");
            //warrior2.Attack("the evildoers");
            #endregion

            #region with NInject
            IKernel kernel = new StandardKernel();
            kernel.Bind<IWeapon>().To<Sword>();
            var samurai = kernel.Get<Samurai>();            
            samurai.Attack("the evildoers");

            #endregion

            Console.ReadLine();
        }
    }
}
