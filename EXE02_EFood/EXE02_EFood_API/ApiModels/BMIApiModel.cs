using Microsoft.AspNetCore.Mvc;

namespace EXE02_EFood_API.ApiModels
{
    public class BMIApiModel
    {
        public float height { get; set; }
        public float weight { get; set; }
        public food getResult()
        {
            float result = weight / (height * height / 10000);
            return new food(result);
        }
    }
    public class food
    {
        public float bmi;
        public string status { get; set; }
        public string breakfirst { get; set; }
        public string snacks1 { get; set; }
        public string lunch { get; set; }
        public string snacks2 { get; set; }
        public string dinner { get; set; }
        public string snacks3 { get; set; }
        public food(float nobmi)
        {
            bmi = nobmi;
            if (bmi <= 18.5)
            {
                status =  "BMI của bạn: "+ nobmi+". Bạn đang gặp phải tình trạng thiếu cân, vì thế nên áp dụng các phương pháp ăn uống và luyện tập để tăng trọng lượng cơ thể.";
                breakfirst = "1 tô phở, 1 quả trứng hoặc 2 ổ bánh mì, 2 trứng ốp la, cũng có thể chọn 1 đĩa cơm sườn hoặc mì xào sườn nướng, nhớ kèm 1 ly sữa, trái cây.";
                snacks1 = "khoảng 10 giờ sáng: 1 phần ngũ cốc cho bữa sáng ít tinh bột như phở hay bánh mì hoặc 1 phần sinh tố, bánh ngọt.";
                lunch = "2 chén cơm, canh rau ngót thịt xay + 100g thịt bò xào ớt chuông, canh bí đỏ nấu tôm + thịt bò xào đầu rồng hoặc thịt kho trứng + canh cải thảo nấu tôm, nhớ kèm trái cây, đây là bữa quan trọng nên chú trọng tinh bột";
                snacks2 = "khoảng 3 giờ 30 chiều: 1 đĩa trái cây, 1 phần súp hoặc 1 phần bánh mì ngọt, 1 ly sữa.";
                dinner = " 2 chén cơm, canh xương hầm rau củ + thịt heo xào đậu que, canh cải ngọt nấu nấm + đậu hũ nhồi thịt, canh đậu hũ nấm + mực xào chua ngọt, nước ép trái cây";
                snacks3 = "1 tô miến nhỏ, 1 phần súp hoặc 1 tô bún nhỏ, 1 đĩa trái cây.";
            }
            else if (bmi <= 24.9)
            {
                status = "BMI của bạn: " + nobmi + ".Bạn đang sở hữu cân nặng khỏe mạnh, cần duy trì quá trình ăn uống và sinh hoạt như thường ngày. Về thực đơn, bạn có thể chọn những món Eat Clean hoặc Dash cho người ăn kiêng.";
                breakfirst = "Một hộp sữa chua không đường và một nửa gói ngũ cốc. Yến mạch và nho khô, trứng ốp ăn kèm bơ + cà chua + đậu ";
                snacks1 = "Trái cây (cam, chuối, lê) hoặc bạn có thể ăn thêm hạnh nhân hoặc trái cây tươi mát";
                lunch = "Bông cải xanh baby và ức gà xào chua ngọt, Gà xào cải bó xôi + miến + rong biển hoặc nếu đã chán những bữa eat clean có thể chọn Canh khổ qua nhồi thịt + Đùi gà chiên + Rau sống + Cá nục kho tiêu hoặc Canh cá diêu hồng + Đậu rim thịt bằm + Mướp ngọt xào bò";
                snacks2 = "Khoảng 15 giờ bạn có thể bổ sung cho cơ thể sữa chua không đường hoặc sinh tố bơ hoặc nước ép táo";
                dinner = "1 đĩa rau salad trộn xà lách, cà chua hoặc cơm gạo lứt và salad bắp hạt";
            }
            else if (bmi <= 29.0)
            {
                status = "BMI của bạn: " + nobmi + ".Bạn đang trong tình trạng thừa cân, cần áp dụng thực đơn ăn kiêng hợp lý cùng việc luyện tập khoa học để lấy lại vóc dáng chuẩn nhất.";
                breakfirst = "1 cốc cà phê đen/trà xanh + nửa quả cam + 1 lát bánh mì bơ đậu phộng hoặc bơ hạnh nhân hoặc Một tô sữa chua Hy Lạp với dâu tây thái lát + quả óc chó và hạt chia cũng có thể chọn Bông cải xanh và phô mai Parmesan";
                lunch = "Canh bí đỏ nấu với bơ bà đậu gà hoặc Bông cải+ phô mai kem ít béo+ sữa chua nguyên chất ít béo với hạt lanh + nửa quả đào + bánh quy không muối cũng có thể chọn Cơm gạo lứt ăn với cá hồi và đậu nành Nhật";
                snacks2 = "Kiwi hoặc các loại quả";
                dinner = "Gà tây và xà lách,  Cơm gạo lứt ăn với cá hồi hấp và măng tây, hoặc Cá hồi, đậu cô ve, hạnh nhân, salad với sốt ít béo, sữa tách béo và một quả cam ";
            }
            else
            {
                status = "BMI của bạn: " + nobmi + ".Bạn đang bị béo phì và tình trạng này có thể khiến bạn gặp rất nhiều vấn đề về sức khỏe cũng như trong sinh hoạt.";
                breakfirst = "1 lát bánh mì nướng + 1 quả trứng luộc + 2-3 quả chuối hoặc 1 lát bơ/phô mai + 1 quả táo + 5-7 bánh quy mặn tốt nhất nên uống một cốc sinh tố để cơ thể đủ năng lượng cho ngày mới. Nên dùng từ 3-4 thành phần như dâu tây, việt quất, mâm xôi, sữa hạnh nhân không đường, dứa, chuối, cải xoăn, rau bina, đậu ngọt…";
                lunch = "1 chén phô mai tươi + 1 quả trứng luộc,  1 lát bánh mì nướng+ 1 quả trứng luộc, cũng có thể làm salad giải độc bằng cách kết hợp rau trộn như rau bina, cải kale, cải bruxen, cam, bơ, hạnh nhân, gà luộc, hành tím, hạt quinoa nấu chín, bơ đậu phộng, dầu mè, nước tương gừng ít natri, muối, hạt tiêu…";
                dinner = "100g thịt trắng + 100g đậu hà lan + 2-3 quả trứng + 1 viên kem vani + 1 quả táo, 2-3 xúc xích + 50g cà rốt luộc + 50g súp lơ + 2-3 quả chuối + 1 viên kem vani + 1 hộp cá ngừ + 2-3 quả chuối + 1 viên kem hoặc sử dụng các thực phẩm trộn salad như cà chua, đậu đen, hạt ngô, sữa chua Hy Lạp, khoai tây nướng, dầu hạnh nhân, súp lơ, bắp cải, củ cải, ngũ cốc nguyên hạt chưa tinh chế, bí xanh, lòng trắng trứng, nấm…";
            }
        }
    }
}
