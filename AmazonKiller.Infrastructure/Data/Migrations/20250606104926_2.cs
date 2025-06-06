using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Code", "DiscountPercent", "ImageUrls", "Name", "Price", "Quantity", "Rating", "ReviewsCount", "SoldCount" },
                values: new object[,]
                {
                    { new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), new Guid("2f4f0438-f456-4770-9d49-1a46ed4ec88a"), "HOU-002", null, "[\"https://m.media-amazon.com/images/I/31lXMBFhMpL._SX522_.jpg\"]", "Silicone Toilet Brush & Holder", 19.99m, 100, 0m, 0, 0 },
                    { new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"), "FUR-003", null, "[\"https://cdn1.jysk.com/getimage/wd3.medium/236364\",\"https://cdn1.jysk.com/getimage/wd3.medium/236369\",\"https://cdn1.jysk.com/getimage/wd3.medium/236365\"]", "Minimalist Bedside Table", 59.99m, 40, 0m, 0, 0 },
                    { new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"), "WTL-003", null, "[\"https://specprom-kr.com.ua/image/cache/catalog/image/catalog/files/perchatki-mbs-pokrytye-nitrilom-tverdyj-manzhet-564x564.webp\"]", "Heavy-Duty Utility Gloves", 24.99m, 80, 0m, 0, 0 },
                    { new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"), "ELE-005", null, "[\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/2/000202052_1054_1054.jpeg\",\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/3/000202053_1054_1054.jpeg\",\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/4/000202054_1054_1054.jpeg\",\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/5/000202055_1054_1054.jpeg\",\"https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/6/000202056_1054_1054.jpeg\"]", "Sony Alpha a6400 Mirrorless Camera", 899.99m, 25, 0m, 0, 0 },
                    { new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"), new Guid("4f528321-f67e-4b7f-b5fa-8a5f2eec93f4"), "FAS-005", null, "[\"https://img.kwcdn.com/product/open/17a385505e6240aaa133bfb681d557a5-goods.jpeg?imageView2/2/w/800/q/70/format/webp\",\"https://img.kwcdn.com/product/open/61685065fd0e459d9af558fcf949ee83-goods.jpeg?imageView2/2/w/800/q/70/format/webp\"]", "Stylish Women's Summer Hat", 34.99m, 40, 0m, 0, 0 },
                    { new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), new Guid("22e7ee0d-8962-482b-857d-43ba828de1ff"), "ELE-003", null, "[\"https://content2.rozetka.com.ua/goods/images/big/423031985.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/423031986.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/423031987.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/423031988.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/423031989.jpg\"]", "Lenovo ThinkPad X1 Carbon Gen 11", 1899.99m, 25, 0m, 0, 0 },
                    { new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), new Guid("fe0cc97e-2f84-456e-bd53-cb9435d94343"), "FUR-003", null, "[\"https://kupistul.ua/public/upload/catalogGood/kreslo-flex-mesh-cherniy-cherniy-106850112-0995.jpg\",\"https://kupistul.ua/public/upload/catalogGoodPhoto/kreslo-flex-mesh-cherniy-cherniy-106850112-77445.jpg\",\"https://kupistul.ua/public/upload/catalogGoodPhoto/kreslo-flex-mesh-cherniy-cherniy-106850112-77446.jpg\"]", "Ergonomic Office Chair with Lumbar Support", 249.99m, 50, 0m, 0, 0 },
                    { new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), new Guid("6fa8707d-97d7-41a1-9c31-50f07b8466f4"), "HOU-003", null, "[\"https://content2.rozetka.com.ua/goods/images/big/378171578.jpg\",\"https://content2.rozetka.com.ua/goods/images/big/378171579.jpg\",\"https://content1.rozetka.com.ua/goods/images/big/378171580.jpg\"]", "Collapsible Laundry Basket", 19.99m, 100, 0m, 0, 0 },
                    { new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), new Guid("d15224c7-41c1-4a87-963c-9c0de97cb5a7"), "TOOL-005", null, "[\"https://biko.ua/image/cache/catalog/product/19139/195700-500x500.jpg\",\"https://biko.ua/image/cache/catalog/product/19139/5bbab5-500x500.jpg\"]", "3M Safety Helmet H-700 Series", 35.99m, 150, 0m, 0, 0 },
                    { new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"), "FAS-003", null, "[\"https://img.modivo.cloud/product(5/4/5/9/54595f77bbbe0dda2ded1c7a961e279ff9bd34a7_0000207922853_01_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp\",\"https://img.modivo.cloud/product(1/f/8/9/1f89d5521273cfa7afca6e03500f99cb54bb9501_0000207922853_03_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp\",\"https://img.modivo.cloud/product(6/d/0/0/6d009576160e83813798096c877e9b7ee1b329a5_0000207922853_02_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp\"]", "Nike Air Max 270 Women’s", 129.99m, 60, 0m, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductAttributes",
                columns: new[] { "Id", "Key", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), "Resolution", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), "24.2MP" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), "Sensor", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), "APS-C CMOS" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), "Video", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), "4K UHD" },
                    { new Guid("00000000-0000-0000-0000-000000000104"), "Lens Mount", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"), "Sony E-mount" },
                    { new Guid("00000000-0000-0000-0000-000000000141"), "Material", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), "High-Density Polyethylene" },
                    { new Guid("00000000-0000-0000-0000-000000000142"), "Suspension", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), "4-point ratchet" },
                    { new Guid("00000000-0000-0000-0000-000000000143"), "Ventilation", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), "Yes" },
                    { new Guid("00000000-0000-0000-0000-000000000144"), "Standard", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"), "ANSI/ISEA Z89.1-2014" },
                    { new Guid("00000000-0000-0000-0000-000000000311"), "Material", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), "Polyester" },
                    { new Guid("00000000-0000-0000-0000-000000000312"), "Capacity", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), "60L" },
                    { new Guid("00000000-0000-0000-0000-000000000313"), "Foldable", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), "Yes" },
                    { new Guid("00000000-0000-0000-0000-000000000314"), "Weight", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"), "0.5kg" },
                    { new Guid("00000000-0000-0000-0000-000000000321"), "Material", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), "Mesh + Foam" },
                    { new Guid("00000000-0000-0000-0000-000000000322"), "Color", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), "Black" },
                    { new Guid("00000000-0000-0000-0000-000000000323"), "Adjustable Height", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), "Yes" },
                    { new Guid("00000000-0000-0000-0000-000000000324"), "Max Weight", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"), "120 kg" },
                    { new Guid("00000000-0000-0000-0000-000000000331"), "Material", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"), "Straw" },
                    { new Guid("00000000-0000-0000-0000-000000000332"), "Color", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"), "Beige" },
                    { new Guid("00000000-0000-0000-0000-000000000333"), "Size", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"), "One Size Fits Most" },
                    { new Guid("14f8a2fd-5c20-439c-b65e-bd697c9ed75a"), "Closure", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), "Velcro strap" },
                    { new Guid("1cf8cf59-8f36-4f7c-b332-97c68a4692c0"), "Color", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), "White/Pink" },
                    { new Guid("27449383-41e3-45f2-84d4-df3d02ec949b"), "Type", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), "Wall-mounted" },
                    { new Guid("2edab99b-17f7-4b63-93c2-8b42066a7d99"), "Color", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), "Oak" },
                    { new Guid("2f4073fd-5296-4d79-90dc-2532c6795bc5"), "Size", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), "M, L, XL" },
                    { new Guid("39ecdb88-44b6-4995-8cb8-e48de889d243"), "Drawers", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), "1 soft-close drawer" },
                    { new Guid("50983ef4-7586-4be1-a6c7-eac4c7fd90a7"), "CPU", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), "Intel Core i7-1355U" },
                    { new Guid("7b7ec203-7f23-47ae-80d1-20b7f936a160"), "Upper", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), "Mesh + Synthetic" },
                    { new Guid("87a5f690-bcb1-4c00-a649-cb40f907e6f3"), "Color", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), "White/Grey" },
                    { new Guid("8b4a31cf-9690-4cbe-a30a-5c6365ab263f"), "Material", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), "Synthetic leather + Spandex" },
                    { new Guid("949da2bb-18d8-4b1c-8e8d-2f10f011d5f7"), "Material", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), "Silicone + Plastic" },
                    { new Guid("adcccfb2-5f3b-44d2-b3bc-0091e084d27f"), "Display", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), "14\" FHD+ IPS" },
                    { new Guid("b390fa02-66b0-4d7b-8f2c-046cd0c93187"), "RAM", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), "16GB LPDDR5" },
                    { new Guid("bd929b9e-d115-41ea-8d6f-5f8c66200ac6"), "Material", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), "Engineered wood" },
                    { new Guid("be3a6d15-cb6b-490a-87f1-6a54bd1614ec"), "Storage", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"), "512GB SSD" },
                    { new Guid("c2d1f858-b56c-487f-9a71-c04d6cba91e3"), "Outsole", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), "Rubber" },
                    { new Guid("c95c1143-dcb0-4010-80a0-4b260303f170"), "Color", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"), "Black/Yellow" },
                    { new Guid("ca0c370e-e27d-4ec6-89b2-1ed26b3db5c3"), "Size", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"), "US 6–10" },
                    { new Guid("d22b2c79-63f2-4c5f-888c-12d569df4455"), "Replaceable Head", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"), "Yes" },
                    { new Guid("fa9b7096-d331-4ed7-a45c-80e0b5d68242"), "Dimensions", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"), "45x40x50 cm" }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000201"), "425 phase-detection points", "Autofocus", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000202"), "180° tiltable LCD", "Screen", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000203"), "Wi-Fi, NFC, Bluetooth", "Connectivity", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000204"), "Magnesium alloy body", "Build", new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000241"), "Soft brow pad and adjustable fit", "Comfort", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005") },
                    { new Guid("00000000-0000-0000-0000-000000000242"), "Impact-resistant outer shell", "Durability", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005") },
                    { new Guid("00000000-0000-0000-0000-000000000243"), "Accessory slots for face shields and earmuffs", "Compatibility", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005") },
                    { new Guid("00000000-0000-0000-0000-000000000401"), "Reinforced carry handles for easy transport", "Handles", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000402"), "Breathable mesh sides", "Design", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000403"), "Compact foldable design", "Storage", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000404"), "Ideal for dorms, apartments, or travel", "Use", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003") },
                    { new Guid("00000000-0000-0000-0000-000000000421"), "Provides lumbar support and breathable mesh back", "Ergonomic Design", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002") },
                    { new Guid("00000000-0000-0000-0000-000000000422"), "360° swivel and smooth rolling wheels", "Mobility", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002") },
                    { new Guid("00000000-0000-0000-0000-000000000423"), "Adjustable height and tilt tension", "Adjustability", new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002") },
                    { new Guid("00000000-0000-0000-0000-000000000431"), "Wide brim blocks UV rays", "Sun Protection", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001") },
                    { new Guid("00000000-0000-0000-0000-000000000432"), "Breathable and lightweight", "Design", new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001") },
                    { new Guid("0072b22f-4b44-4c2b-8fe9-996e1b0aa832"), "Visible Air Max unit", "Cushioning", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2") },
                    { new Guid("19738491-3030-4b3b-9819-353117c4fc5e"), "Quick-drying ventilation base", "Hygiene", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0") },
                    { new Guid("1a2ef03d-456e-4edb-a7b0-31a7088b0596"), "Flexible and snug fit", "Fit", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95") },
                    { new Guid("2bda4a7f-cd79-47b1-94bb-d237e52794ae"), "Sporty & stylish", "Design", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2") },
                    { new Guid("34233ac6-0e32-42b1-9e4f-7c83bcd8fd5f"), "Reinforced knuckles", "Protection", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95") },
                    { new Guid("4a1174ed-faf9-41de-9769-98a7c31560ef"), "Flexible anti-scratch bristles", "Durability", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0") },
                    { new Guid("60e84a9a-e016-4654-a8e4-24e48dc26156"), "Compact storage", "Convenience", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c") },
                    { new Guid("6b747748-3a2a-4c1a-a1b3-8e7d7dbba1f1"), "Textured palm for firm hold", "Grip", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95") },
                    { new Guid("71f2be1d-44a1-4216-96c5-589cba78d144"), "Perforated upper", "Breathability", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2") },
                    { new Guid("8412c1ff-2650-42e3-844b-9a1c36522aa4"), "Foam midsole", "Comfort", new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2") },
                    { new Guid("960b60da-6796-46ce-bb6f-6cc84ef70f1f"), "Legendary ThinkPad tactile typing", "Keyboard", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115") },
                    { new Guid("9c7ad3cf-06f1-4a96-844f-f7c6ae5e0249"), "15+ hour runtime", "Battery", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115") },
                    { new Guid("9f179493-b4d6-4a53-bdc1-d5dd3fa189e3"), "Easy clean surface", "Maintenance", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c") },
                    { new Guid("a40b5a25-8d40-47d5-b509-cf01d6cb44f6"), "No-drill installation", "Convenience", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0") },
                    { new Guid("aeef3fa9-5e61-4bb8-8bff-2b5884c32596"), "Ultra-light carbon fiber body", "Portability", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115") },
                    { new Guid("b8b470f9-3720-4a95-918b-02f6ddbb0f5d"), "Reusable & replaceable head", "Eco-Friendly", new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0") },
                    { new Guid("d891dc16-0e25-4412-b43f-e5f5e2450a70"), "Fingerprint + IR camera", "Security", new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115") },
                    { new Guid("de2955e6-e21e-4ed2-a65e-3b73f708dd7a"), "Mesh back panel", "Breathability", new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95") },
                    { new Guid("e7a8d1a9-30a1-4b89-80d3-90e5a948d914"), "DIY friendly", "Assembly", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c") },
                    { new Guid("f2f2c8fb-0f90-420c-9ed1-5947728f615a"), "Modern minimalist", "Style", new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000101"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000102"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000103"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000104"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000141"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000142"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000143"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000144"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000311"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000312"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000313"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000314"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000321"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000322"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000323"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000324"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000331"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000332"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000333"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("14f8a2fd-5c20-439c-b65e-bd697c9ed75a"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("1cf8cf59-8f36-4f7c-b332-97c68a4692c0"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("27449383-41e3-45f2-84d4-df3d02ec949b"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("2edab99b-17f7-4b63-93c2-8b42066a7d99"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("2f4073fd-5296-4d79-90dc-2532c6795bc5"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("39ecdb88-44b6-4995-8cb8-e48de889d243"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("50983ef4-7586-4be1-a6c7-eac4c7fd90a7"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("7b7ec203-7f23-47ae-80d1-20b7f936a160"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("87a5f690-bcb1-4c00-a649-cb40f907e6f3"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("8b4a31cf-9690-4cbe-a30a-5c6365ab263f"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("949da2bb-18d8-4b1c-8e8d-2f10f011d5f7"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("adcccfb2-5f3b-44d2-b3bc-0091e084d27f"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("b390fa02-66b0-4d7b-8f2c-046cd0c93187"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("bd929b9e-d115-41ea-8d6f-5f8c66200ac6"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("be3a6d15-cb6b-490a-87f1-6a54bd1614ec"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("c2d1f858-b56c-487f-9a71-c04d6cba91e3"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("c95c1143-dcb0-4010-80a0-4b260303f170"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("ca0c370e-e27d-4ec6-89b2-1ed26b3db5c3"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("d22b2c79-63f2-4c5f-888c-12d569df4455"));

            migrationBuilder.DeleteData(
                table: "ProductAttributes",
                keyColumn: "Id",
                keyValue: new Guid("fa9b7096-d331-4ed7-a45c-80e0b5d68242"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000201"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000202"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000203"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000204"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000241"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000242"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000243"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000401"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000402"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000403"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000404"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000421"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000422"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000423"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000431"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000432"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("0072b22f-4b44-4c2b-8fe9-996e1b0aa832"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("19738491-3030-4b3b-9819-353117c4fc5e"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("1a2ef03d-456e-4edb-a7b0-31a7088b0596"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("2bda4a7f-cd79-47b1-94bb-d237e52794ae"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("34233ac6-0e32-42b1-9e4f-7c83bcd8fd5f"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("4a1174ed-faf9-41de-9769-98a7c31560ef"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("60e84a9a-e016-4654-a8e4-24e48dc26156"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("6b747748-3a2a-4c1a-a1b3-8e7d7dbba1f1"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("71f2be1d-44a1-4216-96c5-589cba78d144"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("8412c1ff-2650-42e3-844b-9a1c36522aa4"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("960b60da-6796-46ce-bb6f-6cc84ef70f1f"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("9c7ad3cf-06f1-4a96-844f-f7c6ae5e0249"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("9f179493-b4d6-4a53-bdc1-d5dd3fa189e3"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("a40b5a25-8d40-47d5-b509-cf01d6cb44f6"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("aeef3fa9-5e61-4bb8-8bff-2b5884c32596"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("b8b470f9-3720-4a95-918b-02f6ddbb0f5d"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("d891dc16-0e25-4412-b43f-e5f5e2450a70"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("de2955e6-e21e-4ed2-a65e-3b73f708dd7a"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("e7a8d1a9-30a1-4b89-80d3-90e5a948d914"));

            migrationBuilder.DeleteData(
                table: "ProductFeatures",
                keyColumn: "Id",
                keyValue: new Guid("f2f2c8fb-0f90-420c-9ed1-5947728f615a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2ad39762-dbd2-4959-bf36-03f30e3a3a1c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7777aaaa-bbbb-cccc-dddd-eeee00000001"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7777bbbb-cccc-dddd-eeee-ffff00000001"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("82d2d24a-1dc5-491b-926d-b4e72d168115"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000002"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000003"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8888aaaa-bbbb-cccc-dddd-eeee00000005"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2"));
        }
    }
}
