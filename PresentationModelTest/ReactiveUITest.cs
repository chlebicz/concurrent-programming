using PresentationModel;

namespace PresentationModelTest
{
    public class ReactiveUITest
    {
        [Fact]
        public void ModelBall_ShouldRaisePropertyChanged()
        {
            var ball = new ModelBall();
            bool raisedX = false;
            bool raisedLeft = false;

            ball.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "X") raisedX = true;
                if (e.PropertyName == "Left") raisedLeft = true;
            };

            ball.X = 100;

            Assert.True(raisedX, "PropertyChanged for X was not raised");
            Assert.True(raisedLeft, "PropertyChanged for Left was not raised");
        }

        [Fact]
        public void ModelBall_RadiusChange_ShouldRaiseDiameterChange()
        {
            var ball = new ModelBall();
            bool raisedRadiusX = false;
            bool raisedDiameterX = false;

            ball.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "RadiusX") raisedRadiusX = true;
                if (e.PropertyName == "DiameterX") raisedDiameterX = true;
            };

            ball.RadiusX = 20;

            Assert.True(raisedRadiusX, "PropertyChanged for RadiusX was not raised");
            Assert.True(raisedDiameterX, "PropertyChanged for DiameterX was not raised");
        }
    }
}