using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample2
{
    [TestClass]
    public class CovarianceSamples
    {
        [TestMethod]
        public void Arrays()
        {
            object[] objects = new[] { "a", "b" };
            string[] strings = new string[] { "c", "d" };

            objects = strings;
            //strings = objects; Not legal
        }

        [TestMethod]
        public void Covariance()
        {
            // if Animal=Cat then X<Animal>=X<Cat> - X has a covariant type parameter
            IGet<Animal> animalsGetter = new AnimalsGetter();
            IGet<Cat> catsGetter = new CatsGetter();
            animalsGetter = catsGetter;
            animalsGetter = new CatsGetter();
            Animal animal = animalsGetter.Get(); // cat

            var animalsGetterClass = new AnimalsGetter();
            var catsGetterClass = new CatsGetter();
            // illigal assignment for class (for interface OK)
            //animalsGetterClass = catsGetterClass;
            //animalsGetterClass = new CatGetter();
        }

        [TestMethod]
        public void Contravariance()
        {
            ISet<Animal> animalsSetter = new AnimalsSetter();
            ISet<Cat> catsSetter = new AnimalsSetter(); // internally store animals, Cat convertible to Animal - so ok
            catsSetter.Set(new Cat());
        }
    }
    
    class Animal {}
    class Cat : Animal { }
    class Dog : Animal { }

    interface IGet<out T>
    {
        T Get();
    }
    class AnimalsGetter : IGet<Animal>
    {
        public Animal Get() => null;
    }
    class CatsGetter : IGet<Cat>
    {
        public Cat Get() => null;
    }
    class DogsGetter : IGet<Dog>
    {
        public Dog Get() => null;
    }

    interface ISet<in T>
    {
        void Set(T n);
    }
    class AnimalsSetter : ISet<Animal>
    {
        public void Set(Animal n) { }
    }
    class CatsSetter : ISet<Cat>
    {
        public void Set(Cat n) { }
    }
}
