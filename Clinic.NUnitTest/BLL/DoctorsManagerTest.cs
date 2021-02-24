using Moq;
using NUnit.Framework;
using Clinic.Web.BLL.ViewModels;
using Clinic.Web.BLL.Interfaces;

namespace Clinic.NUnitTest
{
    public class SpecialtiesManagerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddSpecialtiesShouldBeNotNull()
        {
            //arrange
            var mock = new Mock<ISpecialtiesManager>();

            SpecialtiesViewModel specialty = new SpecialtiesViewModel
            {
                Name = "НоваСпец"
            };

            //act
            var result = mock.Setup(x => x.AddSpecialty(specialty));

            //assert
            Assert.IsNotNull(result);
        }


/*        [Test]
        public void AddSpecialtiesShouldReturn()
        {
            //arrange
            SpecialtiesViewModel shouldBe = new SpecialtiesViewModel
            {
                Name = "НоваСпец"
            };

            var mock = new Mock<ISpecialtiesManager>();
            SpecialtiesViewModel specialty = new SpecialtiesViewModel
            {
                Name = "НоваСпец"
            };  


            //act
            SpecialtiesViewModel result = (SpecialtiesViewModel)mock.Setup(x => x.AddSpecialty(specialty));
            SpecialtiesViewModel actual = new SpecialtiesViewModel
            {
                Id = result.Id,
                Name = result.Name,
            };


            //assert
            Assert.AreEqual(actual, shouldBe);
        }*/
    }

}