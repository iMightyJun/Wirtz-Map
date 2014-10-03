using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeTime.Models
{
    public static class Constants
    {
        public const int mapHeight = 800;
        public const int mapWidth = 2130;
        public const int CubicleHeight = 35;
        public const int CubicleWidth = 35;
        public const int ITCubicleSmallHeight = 18;
        public const int TripletWidth = 45;
        public const int TripletHeight = 44;

        #region Second Floor, South Side w00t w00t 
        public const int FinanceDoublesHeight = 52;
        public const int FinanceDoublesWidth = 35;

        public const int IT205615_60X = 395;
        public const int IT205626_37Y = 528;
        public const int IT205638_49Y = 563;
        public const int IT204550_60Y = 633;
        public const int IT2056015_25Y = 457;
        
        public const int IT205601_14OddX = 255;
        public const int IT205601_14EvenX = 316;
        public const int IT205601_14Y = 387;

        public const int IT208101_14Y = 255;
        public const int IT208101_14X = 1;

        public const int HROfficeX = 1;
        public const int HROfficeY = 387;
        public const int HROfficeWidth = 62;
        public const int HROfficeHeight = 62;
        public const int HRCubicleX = 88;
        public const int HRCubicleY = 387;
        public const int HRCubicleHeight = 50;
        public const int HRCubicleWidth = 35;

        public const int FinanceDirectorX = 158;
        public const int FinanceDirectorY = 387;
        public const int FinanceDirectorWidth = 62;
        public const int FinanceDirectorHeight = 62;

        public const int Finance209701_19X = 396;
        public const int Finance209701_19Y = 132;

        public const int ExecutiveOfficeHeight = 97;
        public const int ExecutiveOfficeWidth = 88;

        public const int ITDirectorOfficeW = 61;
        public const int ITDirectorOfficeH = 97;
        public const int ITDirectorX = 316;
        public const int ITDirectorY = 703;

        public const int Executive2094_2096X = Constants.IT208101_14X + Constants.FinanceDoublesWidth * 2 + 35;
        public const int Executive2094_2096Y = 132;

        public const int ExecutiveBreakRoomX = 239 + 88 * 4;
        public const int ExecutiveBreakRoomY = 1;
        public const int ExecutiveBreakRoomWidth = 110;
        public const int ExecutiveBreakRoomHeight = 110;

        public const int ExecutiveBoardRoomX = ExecutiveBreakRoomX + ExecutiveBreakRoomWidth;
        public const int ExecutiveBoardRoomY = 1;
        public const int ExecutiveBoardRoomWidth = 926 - ExecutiveBoardRoomX;
        public const int ExecutiveBoardRoomHeight = ExecutiveBreakRoomHeight;

        public const int Room2099X = Finance209701_19X;
        public const int Room2099Y = 350;
        public const int Room2099Width = 45;
        public const int Room2099Height = 50;

        public const int Room2100X = Room2099X + Room2099Width;
        public const int Room2100Y = Room2099Y;
        public const int Room2100Width = Room2099Width;
        public const int Room2100Height = Room2099Height;

        public const int SecondFloorSWomenBRX = Room2100X + Room2100Width;
        public const int SecondFloorSWomenBRY = Room2100Y;
        public const int SecondFloorSWomenBRWidth = 224;
        public const int SecondFloorSWomenBRHeight = Room2100Height;

        public const int SecondFloorSMenBRX = SecondFloorSWomenBRX;
        public const int SecondFloorSMenBRY = SecondFloorSWomenBRY + SecondFloorSWomenBRHeight;
        public const int SecondFloorSMenBRWidth = SecondFloorSWomenBRWidth;
        public const int SecondFloorSMenBRHeight = SecondFloorSWomenBRHeight + 6;


        #endregion

        #region Second Floor, North Side
        
        public const int secondflooroffset = 926;
        public const int SalesDirectorsW = 61;
        public const int SalesDirectorH = 97;
        public const int SalesDirectorX = 0 + Constants.secondflooroffset;
        public const int SalesDirectorY = 703;

        public const int SalesConferenceRoomW = 114;
        public const int SalesConferenceRoomH = 97;

        public const int SalesDirectorNorthX = 1107 + Constants.secondflooroffset;
        public const int SalesDirectorNorthY = 642;

        public const int AllianceX = 1711;
        public const int AllianceY = 80;

        public const int AllianceWalkWidth = 55;
        public const int AllianceInBetween = 30;

        public const int Sales202601_17X = 1414;
        public const int Sales202601_17Y = 502;

        public const int Sales201901_16X = 1292;
        public const int Sales201901_16Y = 132;

        public const int SalesExecutiveX = 1236;
        public const int SalesExecutiveY = 1;

        public const int Room2020X = Sales201901_16X;
        public const int Room2020Y = 240;
        public const int Room2020Width = 120;
        public const int Room2020Height = 70;

        public const int Room2021X = Room2020X + Room2020Width;
        public const int Room2021Y = Room2020Y;
        public const int Room2021Width = Room2020Width;
        public const int Room2021Height = Room2020Height;

        public const int Room2007X = 926;
        public const int Room2007Y = 455 - Room2007Height;
        public const int Room2007Width = 140;
        public const int Room2007Height = 170;

        public const int Room2009X = Room2007X + Room2007Width;
        public const int Room2009Y = Room2007Y;
        public const int Room2009Width = 170;
        public const int Room2009Height = Room2007Height;

        public const int Room2010X = Room2007X;
        public const int Room2010Y = Room2007Y + Room2007Height + 35;
        public const int Room2010Width = Room2007Width;
        public const int Room2010Height = 178;

        public const int Room2011X = Room2010X + Room2010Width;
        public const int Room2011Y = Room2010Y;
        public const int Room2011Width = Room2009Width;
        public const int Room2011Height = Room2010Height;

        public const int SecondFloorNBathroomX = Room2020X;
        public const int SecondFloorNBathroomY = Room2020Y + Room2020Height;
        public const int SecondFloorNBathRoomWidth = Room2020Width + Room2020Width / 2;
        public const int SecondFloorNBathroomHeight = 455 - (Room2020Y + Room2020Height);

        public const int SecondFloorBreakroomX = SecondFloorNBathroomX;
        public const int SecondFloorBreakroomY = SecondFloorNBathroomY + SecondFloorNBathroomHeight;
        public const int SecondFloorBreakroomWidth = SecondFloorNBathRoomWidth / 2;
        public const int SecondFloorBreakroomHeight = (Room2011Y + Room2011Height) - SecondFloorBreakroomY;

        public const int SecondFloorNStairsX = Room2021X + Room2021Width + 35;
        public const int SecondFloorNStairsY = Room2020Y;
        public const int SecondFloorNStairsWidth = 75;
        public const int SecondFloorNStairsHeight = Room2020Height + SecondFloorNBathroomHeight;

        #endregion

        #region First Floor, South Side

        public const int Sales108101_56X = 1;
        public const int Sales108101_56Y = 1;
        public const int FirstFloorSalesWalk = 35;
        public const int FirstFloorCubicleHeight = 62;
        public const int FirstFloorCubicleWidth = 54;

        public const int Sales1066_76X = 1;
        public const int Sales1066_76Y = 416;
        public const int Sales1079_77X = 683;
        public const int Sales1079_77Y = 63;

        public const int NetworkingX = 630;
        public const int NetworkingY = 760;
        public const int NetworkingWidth = 25;
        public const int NetworkingHeight = 38;

        public const int FitnessX = 484;
        public const int FitnessY = 478;
        public const int FitnessWidth = 146;
        public const int FitnessHeight = 322;

        public const int FitnessWomenX = 360;
        public const int FitnessWomenY = FitnessY;
        public const int FitnessWomenWidth = FitnessX - FitnessWomenX;
        public const int FitnessWomenHeight = FitnessHeight / 4 + 1;

        public const int KamX = Sales1079_77X;
        public const int KamY = 270;
        public const int KamWidth = FirstFloorCubicleHeight;
        public const int KamHeight = 200;

        public const int CafeteriaX = 163;
        public const int CafeteriaY = Sales1066_76Y + FirstFloorCubicleHeight;
        public const int CafeteriaWidth = 162;
        public const int CafeteriaHeight = 200;

        public const int FoodPrepX = CafeteriaX;
        public const int FoodPrepY = CafeteriaY + CafeteriaHeight;
        public const int FoodPrepWidth = CafeteriaWidth;
        public const int FoodPrepHeight = 70;

        public const int SouthStairsX = FoodPrepX - SouthStairsWidth;
        public const int SouthStairsY = FoodPrepY;
        public const int SouthStairsWidth = 120;
        public const int SouthStairsHeight = FoodPrepHeight;

        public const int SouthVestibuleX = SouthStairsX;
        public const int SouthVestibuleY = SouthStairsY + SouthStairsHeight;
        public const int SouthVestibuleHeight = mapHeight - SouthVestibuleY;
        public const int SouthVestibuleWidth = 60;
        #endregion

        #region First Floor, North side


        public const int LobbyX = 745;
        public const int LobbyY = 1;
        public const int LobbyWidth = 388;
        public const int LobbyHeight = 330;

        public const int MailRoomX = LobbyX + 60;
        public const int MailRoomY = LobbyY + (LobbyHeight - 124);
        public const int MailRoomWidth = 170;
        public const int MailRoomHeight = 62;

        public const int LobbyStairsX = MailRoomX;
        public const int LobbyStairsY = MailRoomY;
        public const int LobbyStairsWidth = MailRoomWidth + 70;
        public const int LobbyStairsHeight = MailRoomHeight * 2;
        public const int LobbyStairsMidX = LobbyStairsX + LobbyStairsWidth / 2;
        public const int LobbyStairsMidY = LobbyStairsY + LobbyStairsHeight / 2 + 25;

        public const int Room1006X = LobbyX + LobbyWidth + 60;
        public const int Room1006Y = MailRoomY + MailRoomHeight;
        public const int Room1006Height = LobbyStairsHeight - MailRoomHeight;
        public const int Room1006Width = 175;

        public const int Room1007X = Room1006X + Room1006Width;
        public const int Room1007Y = Room1006Y;
        public const int Room1007Width = Room1006Height;
        public const int Room1007Height = Room1006Height;

        public const int NorthBathroomX = Room1006X;
        public const int NorthBathroomY = Room1006Y + Room1006Height;
        public const int NorthBathroomWidth = Room1006Width + Room1007Width;
        public const int NorthBathroomHeight = Room1040_41Height;
        public const int NorthMenBathroomMidX = NorthBathroomX + NorthBathroomWidth / 2;
        public const int NorthMenBathroomMidY = NorthBathroomY + NorthBathroomHeight / 2 + 15;
        public const int NorthWomenBathroomMidX = NorthBathroomX + NorthBathroomWidth / 2;
        public const int NorthWomenBathroomMidY = NorthBathroomY + NorthBathroomHeight / 2 - 15;

        public const int Room1040_41X = 745;
        public const int Room1040_41Y = LobbyHeight + LobbyY;
        public const int Room1040_41Width = LobbyWidth / 2;
        public const int Room1040_41Height = (KamY + KamHeight) - (LobbyY + LobbyHeight);

        public const int DataCenterX = NetworkingX + 160;
        public const int DataCenterY = 510;
        public const int DataCenterWdith = 290;
        public const int DataCenterHeight = 290;

        public const int LiquorStorage1032X = DataCenterX + DataCenterWdith;
        public const int LiquorStorage1032Y = DataCenterY;
        public const int LiquorStorage1032Width = LobbyWidth - DataCenterWdith - 44;
        public const int LiquorStorage1032Height = DataCenterHeight / 2;

        public const int AlchemyX = LiquorStorage1032X + LiquorStorage1032Width;
        public const int AlchemyY = LiquorStorage1032Y;
        public const int AlchemyHeight = DataCenterHeight;
        public const int AlchemyWidth = 440;

        public const int Room1023X = AlchemyX + AlchemyWidth + 70;
        public const int Room1023Y = AlchemyY;
        public const int Room1023Width = 380;
        public const int Room1023Height = AlchemyHeight;

        public const int Room1020X = Room1023X;
        public const int Room1020Y = Room1023Y - 200;
        public const int Room1020Width = Room1023Width;
        public const int Room1020Height = 200;

        public const int Room1017X = Room1023X;
        public const int Room1017Y = 1;
        public const int Room1017Width = Room1023Width;
        public const int Room1017Height = 260;

        public const int Room1009X = LobbyX + LobbyWidth;
        public const int Room1009Y = 1;
        public const int Room1009Width = 150;
        public const int Room1009Height = 185;

        public const int Room1010X = Room1009X + Room1009Width;
        public const int Room1010Y = 1;
        public const int Room1010Width = 200;
        public const int Room1010Height = Room1009Height;

        public const int Room1013X = Room1010X + Room1010Width;
        public const int Room1013Y = 1;
        public const int Room1013Width = AlchemyWidth - Room1010Width - Room1009Width;
        public const int Room1013Height = 110;

        public const int Room1012X = Room1013X;
        public const int Room1012Y = Room1013Y + Room1013Height;
        public const int Room1012Width = Room1013Width;
        public const int Room1012Height = Room1010Height - Room1013Height;

        public const int NorthStairsX = Room1012X;
        public const int NorthStairsY = Room1007Y;
        public const int NorthStairsWidth = Room1012Width;
        public const int NorthStairsHeight = Room1007Height + NorthBathroomHeight;

        #endregion



    }
}