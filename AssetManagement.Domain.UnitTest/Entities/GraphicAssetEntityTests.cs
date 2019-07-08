using AssetManagement.Domain.Entities;
using AssetManagement.Domain.ResolutionConvter;
using AssetManagement.Object.Assets;
using AssetManagement.Repository.Repositories;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace AssetManagement.Domain.UnitTest.Entities
{
    [TestFixture]
    public class GraphicAssetEntityTests
    {
        private Mock<IGraphicAssetRepository> _repoMock;
        private string _sourcePath = "aa/aa.tmp";

        [SetUp]
        public void SetUp()
        {
            _repoMock = new Mock<IGraphicAssetRepository>();
                        
        }

        [Test]
        public void ConvertResolution_GenerateAllResoluationGrapics_GetThreeResolutionGraphics()
        {
            var sourceData = new GraphicAsset() { SourceFilePath = _sourcePath };
            var entity = new GraphicAssetEntity(sourceData, _repoMock.Object);
            var convertMock = new Mock<IResulotionConverter>();
            string newResoFile = "bbb.bb.temp";
            convertMock.Setup(x => x.ConvertGraphicSource(It.Is<string>(s => s.Equals(_sourcePath)), It.IsAny<Resolution>())).Returns(newResoFile);

            entity.ConvertResolution(convertMock.Object);

            Assert.That(sourceData.Graphics.Count, Is.EqualTo(3));
            Assert.That(sourceData.Graphics[0].GraphicPath, Is.EqualTo(newResoFile));
        }

        [Test]
        public void ConvertResolution_GenerateHighResoIsNull_GetTwoResolutionGraphics()
        {
            var sourceData = new GraphicAsset() { SourceFilePath = _sourcePath };
            var entity = new GraphicAssetEntity(sourceData, _repoMock.Object);
            var convertMock = new Mock<IResulotionConverter>();
            string newResoFile = "bbb.bb.temp";
            convertMock.Setup(x => x.ConvertGraphicSource(It.Is<string>(s => s.Equals(_sourcePath)), It.IsAny<Resolution>())).Returns(newResoFile);
            convertMock.Setup(x => x.ConvertGraphicSource(It.Is<string>(s => s.Equals(_sourcePath)), It.Is<Resolution>(re => re.Equals(Resolution.HighReso)))).Returns("");

            entity.ConvertResolution(convertMock.Object);

            Assert.That(sourceData.Graphics.Count, Is.EqualTo(2));
            Assert.That(sourceData.Graphics.FirstOrDefault(x=>x.Resolution == Resolution.HighReso),Is.EqualTo(null));
        }
    }
}
