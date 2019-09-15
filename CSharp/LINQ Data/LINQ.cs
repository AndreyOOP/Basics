using CSharp.LINQ_Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    [TestFixture]
    public class LINQ
    {
        private TestData _data;

        [SetUp]
        public void Setup()
        {
            _data = new TestData();
        }

        [Test]
        public void Where()
        {
            var startFrom_M = _data.Names.Where(name => name[0] == 'M');

            startFrom_M.Print();
        }

        [Test]
        public void WhereWithIndex()
        {
            var eachSecond = _data.Names.Where((name, index) => index % 2 == 0);

            _data.Names.ToLine();
            eachSecond.ToLine();
        }

        [Test]
        public void Select()
        {
            var addXtoBegining = _data.Names.Select(name => $"X {name}");

            addXtoBegining.Print();
        }

        [Test]
        public void SelectWithIndex()
        {
            var selectWithIndex = _data.Names.Select((name, index) => $"{index} {name}");

            _data.Names.ToLine();
            selectWithIndex.ToLine();
        }

        [Test]
        public void SelectMany()
        {
            var splitted = _data.FullNames.SelectMany(fullName => fullName.Split());

            _data.FullNames.ToLine();
            splitted.ToLine();
        }

        [Test]
        public void SelectManyQuerySyntax()
        {
            //var query = from fullName in _data.FullNames
            //            from single in fullName.Split()
            //            select $"{single} came from {fullName}";

            //query.Print();

            var query = _data.FullNames
                .SelectMany(fullName => fullName.Split().Select(name => new { name, fullName }))
                .Select(i => $"{i.name} came from {i.fullName}");

            query.Print();
        }

        [Test]
        public void Concat()
        {
            var concatenated = _data.Names.Concat(_data.Names2);

            concatenated.Print();
        }

        [Test]
        public void Union()
        {
            var union = _data.Names.Union(_data.Names2);

            union.Print();
        }

        [Test]
        public void Intersect()
        {
            var intersect = _data.Names.Intersect(_data.Names2);

            intersect.Print();
        }

        [Test]
        public void TakeWhile()
        {
            var takeWhile = _data.Names.TakeWhile(name => name != "Harry"); //Harry is not included into result sequence

            takeWhile.Print();
        }

        [Test]
        public void Join()
        {
            var joined = _data.Names.Join( //outer collection
                    _data.Names2, //inner collection
                    o => o,  //outer selector
                    i => i, //inner selector
                    (o, i) => $"{o}, {i}" //result selector
                );

            _data.Names.ToLine();
            _data.Names2.ToLine();
            joined.Print();
        }

        [Test]
        public void RevertString()
        {
            var s = "Hello";

            var reverted = s.Reverse().ToArray();
            Console.WriteLine(new string(reverted));
        }

        [Test]
        public void tryfinally()
        {
            try
            {
                //return;
                throw new ArgumentException();

            }catch(ArgumentException ex)
            {
                throw new Exception();
            }
            catch (Exception ex)
            {

            }
            //finally
            //{
            //    Console.WriteLine("Finally");
            //}
        }

        [Test]
        public void Reverse()
        {
            var reversed = _data.Names.Reverse();

            _data.Names.ToLine();
            reversed.ToLine();
        }

        [Test]
        public void Order()
        {
            var ordered = _data.Names.OrderBy(key => key);

            _data.Names.ToLine();
            ordered.ToLine();
            _data.Names.OrderByDescending(key => key).ToLine();
        }

        [Test]
        public void ZipSample()
        {
            var collection1 = Enumerable.Range(1, 5);
            var collection2 = Enumerable.Range(1, 5).Select(i => 2 * i);

            var zipped = collection1.Zip(collection2, (c1, c2) => c1 + c2);

            collection1.ToLineStruct();
            collection2.ToLineStruct();
            zipped.ToLineStruct();
        }
    }
}
