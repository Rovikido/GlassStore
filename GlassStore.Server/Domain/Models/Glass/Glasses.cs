using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace GlassStore.Server.Domain.Models.Glass
{
    public class Glasses : DbBase
    {
        // Existing properties...


        [BsonElement("price")]
        public decimal price { get; set; } // Цена

        [BsonElement("brand")]
        public string Brand { get; set; } // Бренд

        [BsonElement("model")]
        public string Model { get; set; } // Бренд

        [BsonElement("frame_color")]
        public string FrameColor { get; set; } // Цвет оправы

        [BsonElement("lens_color")]
        public string LensColor { get; set; } // Цвет линз

        [BsonElement("frame_material")]
        public string FrameMaterial { get; set; } // Материал оправы

        [BsonElement("lens_material")]
        public string LensMaterial { get; set; } // Материал линз

        [BsonElement("is_prescription")]
        public bool IsPrescription { get; set; } // Наличие рецепта

        [BsonElement("prescription_type")]
        public string PrescriptionType { get; set; } // Тип рецепта

        [BsonElement("frame_width")]
        public double FrameWidth { get; set; } // Ширина оправы

        [BsonElement("bridge_width")]
        public double BridgeWidth { get; set; } // Ширина мостика

        [BsonElement("temple_length")]
        public double TempleLength { get; set; } // Длина заушника

        [BsonElement("gender")]
        public string Gender { get; set; } // Пол

        [BsonElement("shape")]
        public string Shape { get; set; } // Форма

        [BsonElement("style")]
        public List<string> Style { get; set; } // Стиль

        [BsonElement("photos")]
        public List<string> Photos { get; set; } // фото
    }
}