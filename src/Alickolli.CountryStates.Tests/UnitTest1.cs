namespace Alickolli.CountryStates.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void States()
        {
            var states = Country.States("AU");
            states.Should().NotBeEmpty();
        }

        [Test]
        public void State()
        {
            var state = Country.State("AU", "NSW");
            state.Should().NotBeNull();
            state.Name.Should().Be("New South Wales");
        }

        [Test]
        public void Name()
        {
            var name = Country.Name("AU");
            name.Should().Be("Australia");
        }

        [Test]
        public void NameWithState()
        {
            var name = Country.StateName("AU", "NSW");
            name.Should().Be("New South Wales");
        }

        [Test]
        public void Provinces()
        {
            var provinces = Country.Provinces("AU", "NSW");
            provinces.Should().NotBeEmpty();
        }

        [Test]
        public void Province()
        {
            var province = Country.Province("AU", "NSW");
            province.Should().NotBeNull();
            province.Name.Should().Be("New South Wales");
        }
    }
}