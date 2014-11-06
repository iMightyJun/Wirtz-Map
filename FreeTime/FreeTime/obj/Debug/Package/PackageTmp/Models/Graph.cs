using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;


namespace FreeTime.Models
{
    public class Graph
    {
        public List<Vertex> nodes { get; set; }

       
        public Graph(List<Vertex> g)
        {
            this.nodes = g;
        }

        public Graph(Graph g)
        {
            this.nodes = g.nodes;
        }

        public Graph()
        {
            nodes = new List<Vertex>();
        }

        public void makeNodes()
        {
            #region Make First Floor
            //Integers are used not constant values (hallway length, etc)
            Vertex v1001 = new Vertex(Int32.MaxValue, "1001", Constants.LobbyX, Constants.LobbyY, Constants.LobbyWidth, Constants.LobbyHeight);
            Vertex v1002 = new Vertex(Int32.MaxValue, "1002", Constants.MailRoomX, Constants.MailRoomY, Constants.MailRoomWidth, Constants.MailRoomHeight);
            Vertex v1002adj = Vertex.makeAdjacent(ref v1002, "v1022adj", 1, "left", 115);
            this.nodes.Add(v1002adj);
            Vertex v1001adj = Vertex.makeConnect(ref v1001, "v1001adj", 1, v1002adj.midX, v1001.midY);
            this.nodes.Add(v1001adj);

            Vertex v1003 = new Vertex(Int32.MaxValue, "1003", Constants.LobbyStairsX, Constants.LobbyStairsY, Constants.LobbyStairsWidth, Constants.LobbyStairsHeight, Constants.LobbyStairsMidX, Constants.LobbyStairsMidY);
            Vertex v1003adj = Vertex.makeConnect(ref v1003, "v1003adj", 1, v1003.midX + 85, v1003.midY);
            this.nodes.Add(v1003adj);
            Vertex v1003walk = Vertex.makeConnect(ref v1003adj, "v1003walk", 1, v1003adj.midX, v1001.midY);
            this.nodes.Add(v1003walk);

            Vertex v1004 = new Vertex(Int32.MaxValue, "1004", Constants.ElevatorX, Constants.ElevatorY, Constants.ElevatorWidth, Constants.ElevatorHeight);
            Vertex v1004adj = Vertex.makeAdjacent(ref v1004, "v1004adj", 1, "up", 70);
            this.nodes.Add(v1004adj);
            Vertex v1004walk = Vertex.makeConnect(ref v1004adj, "v1004walk", 1, v1004.midX, v1001.midY);
            this.nodes.Add(v1004walk);


            Vertex v1005 = new Vertex(Int32.MaxValue, "1005", Constants.ElevatorX + Constants.ElevatorWidth, Constants.ElevatorY, 60, Constants.ElevatorHeight);
            Vertex v1005adj = Vertex.makeConnect(ref v1005, "v1005adj", 1, v1005.midX, v1004adj.midY);
            this.nodes.Add(v1005adj);
            
            Vertex v1006 = new Vertex(Int32.MaxValue, "1006", Constants.Room1006X, Constants.Room1006Y, Constants.Room1006Width, Constants.Room1006Height);
            Vertex v1006adj = Vertex.makeConnect(ref v1006, "v1006adj", 1, v1006.midX, v1005adj.midY);
            this.nodes.Add(v1006adj);
            
            Vertex v100601 = new Vertex(Int32.MaxValue, "1006.01", 0, 0);
            Vertex v100602 = new Vertex(Int32.MaxValue, "1006.02", 0, 0);
            Vertex v100603 = new Vertex(Int32.MaxValue, "1006.03", 0, 0);
            Vertex v100604 = new Vertex(Int32.MaxValue, "1006.04", 0, 0);
            Vertex v100605 = new Vertex(Int32.MaxValue, "1006.05", 0, 0);
            Vertex v100606 = new Vertex(Int32.MaxValue, "1006.06", 0, 0);
            Vertex v100607 = new Vertex(Int32.MaxValue, "1006.07", 0, 0);
            Vertex v100608 = new Vertex(Int32.MaxValue, "1006.08", 0, 0);
            Vertex v100609 = new Vertex(Int32.MaxValue, "1006.09", 0, 0);
            Vertex v1007 = new Vertex(Int32.MaxValue, "1007", Constants.Room1007X, Constants.Room1007Y, Constants.Room1007Width, Constants.Room1007Height);
            Vertex v1007adj = Vertex.makeAdjacent(ref v1007, "v1007adj", 1, "right", 58);
            this.nodes.Add(v1007adj);
            
            Vertex v1009 = new Vertex(Int32.MaxValue, "1009", Constants.Room1009X, Constants.Room1009Y, Constants.Room1009Width, Constants.Room1009Height);
            Vertex v1009adj = Vertex.makeConnect(ref v1009, "v1009adj", 1, v1005adj.midX, v1009.midY);
            this.nodes.Add(v1009adj);
            
            Vertex v100901 = new Vertex(Int32.MaxValue, "1009.01", 0, 0);
            Vertex v100902 = new Vertex(Int32.MaxValue, "1009.02", 0, 0);
            Vertex v100903 = new Vertex(Int32.MaxValue, "1009.03", 0, 0);
            Vertex v100904 = new Vertex(Int32.MaxValue, "1009.04", 0, 0);
            Vertex v101001 = new Vertex(Int32.MaxValue, "1010.01", Constants.Room1010X, Constants.Room1010Y, Constants.Room1010Width, Constants.Room1010Height);
            Vertex v101001adj = Vertex.makeAdjacent(ref v101001, "v101001adj", 1, "left", 55);
            this.nodes.Add(v101001adj);

            Vertex v1006walk = Vertex.makeConnect(ref v1006adj, "v1006awalk", 1, v101001adj.midX, v1006adj.midY);
            this.nodes.Add(v1006walk);
            Vertex v1007walk = Vertex.makeConnect(ref v1006walk, "v1007adj", 1, v1007.midX, v1006adj.midY);
            this.nodes.Add(v1007walk);
            Vertex v1007corner = Vertex.makeConnect(ref v1007walk, "v1007corner", 1, v1007adj.midX, v1007walk.midY);
            this.nodes.Add(v1007corner);

            Vertex v101002 = new Vertex(Int32.MaxValue, "1010.02", 0, 0);
            Vertex v101003 = new Vertex(Int32.MaxValue, "1010.03", 0, 0);
            Vertex v101004 = new Vertex(Int32.MaxValue, "1010.04", 0, 0);
            Vertex v101005 = new Vertex(Int32.MaxValue, "1010.05", 0, 0);
            Vertex v101006 = new Vertex(Int32.MaxValue, "1010.06", 0, 0);
            Vertex v101007 = new Vertex(Int32.MaxValue, "1010.07", 0, 0);
            Vertex v101008 = new Vertex(Int32.MaxValue, "1010.08", 0, 0);
            Vertex v101009 = new Vertex(Int32.MaxValue, "1010.09", 0, 0);
            Vertex v10101 = new Vertex(Int32.MaxValue, "1010.1", 0, 0);
            
            
            Vertex v101011 = new Vertex(Int32.MaxValue, "1010.11", 0, 0);
            Vertex v101101 = new Vertex(Int32.MaxValue, "1011.01", 0, 0);
            Vertex v101102 = new Vertex(Int32.MaxValue, "1011.02", 0, 0);
            Vertex v101103 = new Vertex(Int32.MaxValue, "1011.03", 0, 0);
            Vertex v101104 = new Vertex(Int32.MaxValue, "1011.04", 0, 0);
            Vertex v101105 = new Vertex(Int32.MaxValue, "1011.05", 0, 0);
            Vertex v101106 = new Vertex(Int32.MaxValue, "1011.06", 0, 0);
            Vertex v1012 = new Vertex(Int32.MaxValue, "1012", Constants.Room1012X, Constants.Room1012Y, Constants.Room1012Width, Constants.Room1012Height);
            Vertex v1012adj = Vertex.makeAdjacent(ref v1012, "v1012adj", 1, "right", 80);
            this.nodes.Add(v1012adj);
            Vertex v101301 = new Vertex(Int32.MaxValue, "1013.01", Constants.Room1013X, Constants.Room1013Y, Constants.Room1013Width, Constants.Room1013Height);
            Vertex v101302 = new Vertex(Int32.MaxValue, "1013.02", 0, 0);
            Vertex v1015 = new Vertex(Int32.MaxValue, "1015", Constants.NorthStairsX, Constants.NorthStairsY, Constants.NorthStairsWidth, Constants.NorthStairsHeight);
            Vertex v1015adj = Vertex.makeConnect(ref v1015, "v1015adj", 1, v1015.midX, v1007corner.midY);
            this.nodes.Add(v1015adj);
            Vertex v1012walk = Vertex.makeConnect(ref v1012adj, "v1012walk", 1, v1012adj.midX, v1015adj.midY);
            this.nodes.Add(v1012walk);

            Vertex v1017 = new Vertex(Int32.MaxValue, "1017", Constants.Room1017X, Constants.Room1017Y, Constants.Room1017Width, Constants.Room1017Height);
            Vertex v1017adj = Vertex.makeConnect(ref v1017, "v1017adj", 1, v1012adj.midX, v1017.midY);
            this.nodes.Add(v1017adj);
            
            
            Vertex v1020 = new Vertex(Int32.MaxValue, "1020", Constants.Room1020X, Constants.Room1020Y, Constants.Room1020Width, Constants.Room1020Height);
            Vertex v1020adj = Vertex.makeConnect(ref v1020, "v1020adj", 1, v1012walk.midX, v1020.midY);
            this.nodes.Add(v1020adj);
            Vertex v1020walk = Vertex.makeConnect(ref v1020adj, "v1020walk", 1, v1020adj.midX, v1020adj.midY + 83);
            this.nodes.Add(v1020walk);

            Vertex v1023 = new Vertex(Int32.MaxValue, "1023", Constants.Room1023X, Constants.Room1023Y, Constants.Room1023Width, Constants.Room1023Height);
            Vertex v1023adj = Vertex.makeConnect(ref v1023, "v1023adj", 1, v1020walk.midX, v1023.midY);
            this.nodes.Add(v1023adj);
            
            Vertex v1025 = new Vertex(Int32.MaxValue, "1025", 0, 0);
            Vertex v1026 = new Vertex(Int32.MaxValue, "1026", 0, 0);
            Vertex v1027 = new Vertex(Int32.MaxValue, "1027", 0, 0);
            Vertex v1028 = new Vertex(Int32.MaxValue, "1028", 0, 0);
            Vertex v1029 = new Vertex(Int32.MaxValue, "1029", 0, 0);
            Vertex v1030 = new Vertex(Int32.MaxValue, "1030", 0, 0);
            Vertex v103101 = new Vertex(Int32.MaxValue, "1031.01", Constants.AlchemyX, Constants.AlchemyY, Constants.AlchemyWidth, Constants.AlchemyHeight);
            Vertex v103101adj = Vertex.makeConnect(ref v103101, "Alchemyadj", 1, v103101.midX, v1020walk.midY);
            this.nodes.Add(v103101adj);
            
            Vertex v103102 = new Vertex(Int32.MaxValue, "1031.02", 0, 0);
            Vertex v1032 = new Vertex(Int32.MaxValue, "1032", Constants.LiquorStorage1032X, Constants.LiquorStorage1032Y,Constants.LiquorStorage1032Width, Constants.LiquorStorage1032Height);
            Vertex v1033 = new Vertex(Int32.MaxValue, "1033", 0, 0);
            Vertex v1037 = new Vertex(Int32.MaxValue, "1037", Constants.NorthBathroomX, Constants.NorthBathroomY, Constants.NorthBathroomWidth, Constants.NorthBathroomHeight, Constants.NorthWomenBathroomMidX, Constants.NorthWomenBathroomMidY);
            Vertex v1037adj = Vertex.makeConnect(ref v1037, "v10137adj", 1, v1007adj.midX, v1037.midY);
            this.nodes.Add(v1037adj);
            
            Vertex v1038 = new Vertex(Int32.MaxValue, "1038", Constants.NorthBathroomX, Constants.NorthBathroomY, Constants.NorthBathroomWidth, Constants.NorthBathroomHeight, Constants.NorthMenBathroomMidX, Constants.NorthMenBathroomMidY);
            Vertex v1038adj = Vertex.makeConnect(ref v1038, "v10138adj", 1, v1007adj.midX, v1038.midY);
            this.nodes.Add(v1038adj);
            Vertex v1038walk = Vertex.makeConnect(ref v1038adj, "v1038walk", 1, v1038adj.midX, v1020walk.midY);
            this.nodes.Add(v1038walk);


            Vertex v1039 = new Vertex(Int32.MaxValue, "1039", Constants.Room1040_41X + Constants.Room1040_41Width *2, Constants.Room1040_41Y, 60, Constants.Room1040_41Height);
            Vertex v1039adj = Vertex.makeConnect(ref v1039, "v1039adj", 1, v1039.midX, v1020walk.midY);
            this.nodes.Add(v1039adj);
            
            Vertex v1040 = new Vertex(Int32.MaxValue, "1040", Constants.Room1040_41X + Constants.Room1040_41Width, Constants.Room1040_41Y, Constants.Room1040_41Width, Constants.Room1040_41Height);
            Vertex v1040adj = Vertex.makeConnect(ref v1040, "v1040adj", 1, v1040.midX, v1020walk.midY);
            this.nodes.Add(v1040adj);
            
            Vertex v1041 = new Vertex(Int32.MaxValue, "1041", Constants.Room1040_41X, Constants.Room1040_41Y, Constants.Room1040_41Width, Constants.Room1040_41Height);
            Vertex v1041adj = Vertex.makeConnect(ref v1041, "v1041adj", 1, v1041.midX, v1020walk.midY);
            this.nodes.Add(v1041adj);
            
            
            Vertex v1043 = new Vertex(Int32.MaxValue, "1043", Constants.DataCenterX, Constants.DataCenterY, Constants.DataCenterWdith, Constants.DataCenterHeight);


            #region Connect First Floor North Side

            Vertex.connectVertex(ref v1001adj, ref v1002adj);
            Vertex.connectVertex(ref v1001, ref v1003walk);
            Vertex.connectVertex(ref v1001, ref v1004walk);
            Vertex.connectVertex(ref v1004adj, ref v1005adj);
            Vertex.connectVertex(ref v1005adj, ref v1009adj);
            Vertex.connectVertex(ref v1005adj, ref v1006adj);
            Vertex.connectVertex(ref v1006walk, ref v101001adj);
            Vertex.connectVertex(ref v1007adj, ref v1007corner);
            Vertex.connectVertex(ref v1007corner, ref v1015adj);
            Vertex.connectVertex(ref v1012, ref v101301);
            Vertex.connectVertex(ref v1012walk, ref v1015adj);
            Vertex.connectVertex(ref v1017adj, ref v1012adj);
            Vertex.connectVertex(ref v1020adj, ref v1012walk);
            Vertex.connectVertex(ref v1007adj, ref v1037adj);
            Vertex.connectVertex(ref v1037adj, ref v1038adj);
            Vertex.connectVertex(ref v1038walk, ref v1020walk);
            Vertex.connectVertex(ref v1023adj, ref v1020walk);
            Vertex.connectVertex(ref v103101adj, ref v1038walk);
            Vertex.connectVertex(ref v103101adj, ref v1039adj);
            Vertex.connectVertex(ref v1040adj, ref v1039adj);
            Vertex.connectVertex(ref v1040adj, ref v1041adj);
            #endregion


            Vertex v104501 = new Vertex(Int32.MaxValue, "1045.01", Constants.NetworkingX, Constants.NetworkingY, Constants.NetworkingWidth, Constants.NetworkingHeight);
            Vertex v104502 = new Vertex(Int32.MaxValue, "1045.02", Constants.NetworkingX + Constants.NetworkingWidth, Constants.NetworkingY, Constants.NetworkingWidth, Constants.NetworkingHeight);
            Vertex v104503 = new Vertex(Int32.MaxValue, "1045.03", Constants.NetworkingX + Constants.NetworkingWidth*2, Constants.NetworkingY, Constants.NetworkingWidth, Constants.NetworkingHeight);
            Vertex v104504 = new Vertex(Int32.MaxValue, "1045.04", Constants.NetworkingX + Constants.NetworkingWidth*3, Constants.NetworkingY, Constants.NetworkingWidth, Constants.NetworkingHeight);
            Vertex v1046 = new Vertex(Int32.MaxValue, "1046", 630, 600, 116, 200);
            Vertex v1046adj = Vertex.makeAdjacent(ref v1046, "v1046adj", 1, "right", 80);
            this.nodes.Add(v1046adj);
            
            Vertex v1047 = new Vertex(Int32.MaxValue, "1047", 0, 0);
            Vertex v1048 = new Vertex(Int32.MaxValue, "1048", 630, 510, 116, 90 );
            Vertex v1048adj = Vertex.makeAdjacent(ref v1048, "v1048adj", 1, "right", 80);
            this.nodes.Add(v1048adj);

            Vertex v1043adj = Vertex.makeConnect(ref v1043, "v1043adj", 1, v1048adj.midX, v1043.midY);
            this.nodes.Add(v1043adj);

            Vertex v104801 = new Vertex(Int32.MaxValue, "1048.01", 0, 0);
            Vertex v104802 = new Vertex(Int32.MaxValue, "1048.02", 0, 0);
            Vertex v104803 = new Vertex(Int32.MaxValue, "1048.03", 0, 0);
            Vertex v104804 = new Vertex(Int32.MaxValue, "1048.04", 0, 0);
            Vertex v104805 = new Vertex(Int32.MaxValue, "1048.05", 0, 0);
            Vertex v104806 = new Vertex(Int32.MaxValue, "1048.06", 0, 0);
            Vertex v1049 = new Vertex(Int32.MaxValue, "1049", Constants.FitnessX, Constants.FitnessY, Constants.FitnessWidth, Constants.FitnessHeight);
            Vertex v1049adj = Vertex.makeAdjacent(ref v1049, "v1049adj", 1, "up", 145);
            this.nodes.Add(v1049adj);
            Vertex v1048walk = Vertex.makeConnect(ref v1048adj, "v1048walk", 1, v1048adj.midX, v1049adj.midY);
            this.nodes.Add(v1048walk);
            
            Vertex v1050 = new Vertex(Int32.MaxValue, "1050", Constants.FitnessWomenX, Constants.FitnessWomenY + Constants.FitnessWomenHeight*3, Constants.FitnessWomenWidth, Constants.FitnessWomenHeight);
            Vertex v1050adj = Vertex.makeAdjacent(ref v1050, "v1050adj", 1, "left", 80);
            this.nodes.Add(v1050adj);
            
            Vertex v1052 = new Vertex(Int32.MaxValue, "1052", Constants.FitnessWomenX, Constants.FitnessWomenY + Constants.FitnessWomenHeight*2, Constants.FitnessWomenWidth, Constants.FitnessWomenHeight);
            Vertex v1052adj = Vertex.makeConnect(ref v1052, "v1052adj", 1, v1050adj.midX, v1052.midY);
            this.nodes.Add(v1052adj);
            
            Vertex v1053 = new Vertex(Int32.MaxValue, "1053", Constants.FitnessWomenX, Constants.FitnessWomenY + Constants.FitnessWomenHeight, Constants.FitnessWomenWidth, Constants.FitnessWomenHeight);
            Vertex v1053adj = Vertex.makeConnect(ref v1053, "v1053adj", 1, v1050adj.midX, v1053.midY);
            this.nodes.Add(v1053adj);
            
            Vertex v1055 = new Vertex(Int32.MaxValue, "1055", Constants.FitnessWomenX, Constants.FitnessWomenY, Constants.FitnessWomenWidth, Constants.FitnessWomenHeight);
            Vertex v1055adj = Vertex.makeConnect(ref v1055, "v1055adj", 1, v1052adj.midX, v1055.midY);
            this.nodes.Add(v1055adj);
            Vertex v1059 = new Vertex(Int32.MaxValue, "1059", Constants.SouthVestibuleX, Constants.SouthVestibuleY, Constants.SouthVestibuleWidth, Constants.SouthVestibuleHeight);
            Vertex v1059adj = Vertex.makeAdjacent(ref v1059, "v1059adj", 1, "right", 65);
            this.nodes.Add(v1059adj);
            
            Vertex v1060 = new Vertex(Int32.MaxValue, "1060", Constants.SouthStairsX, Constants.SouthStairsY, Constants.SouthStairsWidth, Constants.SouthStairsHeight);
            

            Vertex v1060S = new Vertex(Int32.MaxValue, "2v1060S", Constants.HROfficeX + Constants.HROfficeWidth , 730 - Constants.SouthStairsHeight - 23, 157, Constants.SouthStairsHeight + 25);
            v1060S.info = new Person("South Stair", "", "2v1060S", "", "", "Stairs");
            // Connect Staircases
            Vertex v1060Sadj = Vertex.makeAdjacent(ref v1060S, "v1060Sadj", 2, "right", 61);
            this.nodes.Add(v1060Sadj);
            Vertex v1060adj = Vertex.makeConnect(ref v1060, "v1060adj", 1, v1059adj.midX, v1060.midY);
            this.nodes.Add(v1060adj);

            Vertex v1061 = new Vertex(Int32.MaxValue, "1061", Constants.FoodPrepX, Constants.FoodPrepY, Constants.FoodPrepWidth, Constants.FoodPrepHeight);
            Vertex v1061adj = Vertex.makeConnect(ref v1061, "v1061adj", 1, v1061.midX, v1059adj.midY);
            this.nodes.Add(v1061adj);
            Vertex v1061walk = Vertex.makeConnect(ref v1061adj, "v1061walk", 1, v1050adj.midX, v1061adj.midY);
            this.nodes.Add(v1061walk);
            

            Vertex v1063 = new Vertex(Int32.MaxValue, "1063", 0, 0);
            Vertex v1064 = new Vertex(Int32.MaxValue, "1064", 0, 0);
            Vertex v1065 = new Vertex(Int32.MaxValue, "1065", Constants.CafeteriaX, Constants.CafeteriaY, Constants.CafeteriaWidth, Constants.CafeteriaHeight);
            Vertex v1065adj = Vertex.makeConnect(ref v1065, "v1065adj", 1, v1053adj.midX, v1065.midY);
            this.nodes.Add(v1065adj);


            //Connect south side enterance
            #region Connect Southside Enterance
            Vertex.connectVertex(ref v1060, ref v1060S, 100);
            Vertex.connectVertex(ref v1060adj, ref v1059adj);
            Vertex.connectVertex(ref v1061adj, ref v1059adj);
            Vertex.connectVertex(ref v1061walk, ref v1050adj);
            Vertex.connectVertex(ref v1052adj, ref v1050adj);
            Vertex.connectVertex(ref v1053adj, ref v1052adj);
            Vertex.connectVertex(ref v1065adj, ref v1053adj);
            Vertex.connectVertex(ref v1055adj, ref v1065adj);
            #endregion

            Vertex v1066 = new Vertex(Int32.MaxValue, "1066", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 0, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1067 = new Vertex(Int32.MaxValue, "1067", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 1, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1068 = new Vertex(Int32.MaxValue, "1068", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 2, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1069 = new Vertex(Int32.MaxValue, "1069", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 3, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1070 = new Vertex(Int32.MaxValue, "1070", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 4, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1071 = new Vertex(Int32.MaxValue, "1071", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 5, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1072 = new Vertex(Int32.MaxValue, "1072", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 6 + Constants.FirstFloorSalesWalk, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1073 = new Vertex(Int32.MaxValue, "1073", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 7 + Constants.FirstFloorSalesWalk, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1074 = new Vertex(Int32.MaxValue, "1074", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 8 + Constants.FirstFloorSalesWalk, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1075 = new Vertex(Int32.MaxValue, "1075", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 9 + Constants.FirstFloorSalesWalk, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v1076 = new Vertex(Int32.MaxValue, "1076", Constants.Sales1066_76X + Constants.FirstFloorCubicleWidth * 10 + Constants.FirstFloorSalesWalk, Constants.Sales1066_76Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            

            Vertex v1077 = new Vertex(Int32.MaxValue, "1077", Constants.KamX, Constants.KamY, Constants.KamWidth, Constants.KamHeight);
            Vertex v1077adj = Vertex.makeAdjacent(ref v1077, "v1077adj", 1, "up", 80, 2);
            this.nodes.Add(v1077adj);
            Vertex v1077walk = Vertex.makeAdjacent(ref v1077adj, "v1077walk", 1, "left", 40);
            this.nodes.Add(v1077walk);
            Vertex v1077adj2 = Vertex.makeAdjacent(ref v1077, "v1077adj2", 1, "down", 80, 2);
            this.nodes.Add(v1077adj2);
            Vertex v1077walk2 = Vertex.makeAdjacent(ref v1077adj2, "v1077walk2", 1, "left", 40);
            this.nodes.Add(v1077walk2);
            Vertex v107701 = new Vertex(Int32.MaxValue, "1077.01", 0, 0);
            Vertex v107702 = new Vertex(Int32.MaxValue, "1077.02", 0, 0);
            Vertex v107703 = new Vertex(Int32.MaxValue, "1077.03", 0, 0);
            Vertex v107704 = new Vertex(Int32.MaxValue, "1077.04", 0, 0);
            Vertex v107705 = new Vertex(Int32.MaxValue, "1077.05", 0, 0);
            Vertex v107706 = new Vertex(Int32.MaxValue, "1077.06", 0, 0);
            Vertex v107707 = new Vertex(Int32.MaxValue, "1077.07", 0, 0);
            Vertex v107708 = new Vertex(Int32.MaxValue, "1077.08", 0, 0);
            Vertex v107709 = new Vertex(Int32.MaxValue, "1077.09", 0, 0);
            Vertex v10771 = new Vertex(Int32.MaxValue, "1077.1", 0, 0);
            Vertex v107711 = new Vertex(Int32.MaxValue, "1077.11", 0, 0);
            Vertex v107712 = new Vertex(Int32.MaxValue, "1077.12", 0, 0);
            Vertex v107713 = new Vertex(Int32.MaxValue, "1077.13", 0, 0);
            Vertex v107714 = new Vertex(Int32.MaxValue, "1077.14", 0, 0);
            Vertex v107715 = new Vertex(Int32.MaxValue, "1077.15", 0, 0);
            Vertex v10771601 = new Vertex(Int32.MaxValue, "1077.16.01", 0, 0);
            Vertex v10771602 = new Vertex(Int32.MaxValue, "1077.16.02", 0, 0);
            Vertex v1078 = new Vertex(Int32.MaxValue, "1078", Constants.Sales1079_77X, Constants.Sales1079_77Y + Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight, Constants.FirstFloorCubicleWidth);
            Vertex v1078adj = Vertex.makeConnect(ref v1078, "v1078adj", 1, v1077walk.midX, v1078.midY);
            this.nodes.Add(v1078adj);
            Vertex v1079 = new Vertex(Int32.MaxValue, "1079", Constants.Sales1079_77X, Constants.Sales1079_77Y, Constants.FirstFloorCubicleHeight, Constants.FirstFloorCubicleWidth);
            Vertex v1079adj = Vertex.makeConnect(ref v1079, "v1078adj", 1, v1077walk.midX, v1079.midY);
            this.nodes.Add(v1079adj);

            Vertex v1080 = new Vertex(Int32.MaxValue, "1080", 649, 1, 96 ,62);
            Vertex v1080adj = Vertex.makeConnect(ref v1080, "v1080adj", 1, v1077walk.midX, v1080.midY);
            this.nodes.Add(v1080adj);
            Vertex v108101 = new Vertex(Int32.MaxValue, "1081.01", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 0, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108101adj = Vertex.makeAdjacent(ref v108101, "v108101adj", 1, "down", 48);
            this.nodes.Add(v108101adj);
            
            Vertex v108102 = new Vertex(Int32.MaxValue, "1081.02", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 1, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108103 = new Vertex(Int32.MaxValue, "1081.03", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 2, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108104 = new Vertex(Int32.MaxValue, "1081.04", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 3, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108105 = new Vertex(Int32.MaxValue, "1081.05", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 4, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108106 = new Vertex(Int32.MaxValue, "1081.06", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 5, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108107 = new Vertex(Int32.MaxValue, "1081.07", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 6, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108108 = new Vertex(Int32.MaxValue, "1081.08", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 7, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108109 = new Vertex(Int32.MaxValue, "1081.09", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 8, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v10811 = new Vertex(Int32.MaxValue, "1081.1", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 9, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108111 = new Vertex(Int32.MaxValue, "1081.11", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 10, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108112 = new Vertex(Int32.MaxValue, "1081.12", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 11, Constants.Sales108101_56Y, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);

            Vertex v108102adj = Vertex.makeConnect(ref v108102, "v108102adj", 1, v108102.midX, v108101adj.midY);
            this.nodes.Add(v108102adj);
            Vertex v108103adj = Vertex.makeConnect(ref v108103, "v108103adj", 1, v108103.midX, v108101adj.midY);
            this.nodes.Add(v108103adj);
            Vertex v108104adj = Vertex.makeConnect(ref v108104, "v108104adj", 1, v108104.midX, v108101adj.midY);
            this.nodes.Add(v108104adj);
            Vertex v108105adj = Vertex.makeConnect(ref v108105, "v108105adj", 1, v108105.midX, v108101adj.midY);
            this.nodes.Add(v108105adj);
            Vertex v108106adj = Vertex.makeConnect(ref v108106, "v108106adj", 1, v108106.midX, v108101adj.midY);
            this.nodes.Add(v108106adj);
            Vertex v108107adj = Vertex.makeConnect(ref v108107, "v108107adj", 1, v108107.midX, v108101adj.midY);
            this.nodes.Add(v108107adj);
            Vertex v108107walk = Vertex.makeConnect(ref v108107adj, "v108107walk", 1, v108107.midX + 25, v108101adj.midY);
            this.nodes.Add(v108107walk);
            
            Vertex v108108adj = Vertex.makeConnect(ref v108108, "v108108adj", 1, v108108.midX, v108101adj.midY);
            this.nodes.Add(v108108adj);
            Vertex v108109adj = Vertex.makeConnect(ref v108109, "v108109adj", 1, v108109.midX, v108101adj.midY);
            this.nodes.Add(v108109adj);
            Vertex v108110adj = Vertex.makeConnect(ref v10811, "v108110adj", 1, v10811.midX, v108101adj.midY);
            this.nodes.Add(v108110adj);
            Vertex v108111adj = Vertex.makeConnect(ref v108111, "v108111adj", 1, v108111.midX, v108101adj.midY);
            this.nodes.Add(v108111adj);
            Vertex v108112adj = Vertex.makeConnect(ref v108112, "v108112adj", 1, v108112.midX, v108101adj.midY);
            this.nodes.Add(v108112adj);


            Vertex v108113 = new Vertex(Int32.MaxValue, "1081.13", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 0, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108114 = new Vertex(Int32.MaxValue, "1081.14", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 1, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108115 = new Vertex(Int32.MaxValue, "1081.15", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 2, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108116 = new Vertex(Int32.MaxValue, "1081.16", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 3, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108117 = new Vertex(Int32.MaxValue, "1081.17", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 4, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108118 = new Vertex(Int32.MaxValue, "1081.18", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 5, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108119 = new Vertex(Int32.MaxValue, "1081.19", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 6, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v10812 = new Vertex(Int32.MaxValue, "1081.2", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 7, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108121 = new Vertex(Int32.MaxValue, "1081.21", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 8, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108122 = new Vertex(Int32.MaxValue, "1081.22", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 9, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108123 = new Vertex(Int32.MaxValue, "1081.23", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 10, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108114walk = Vertex.makeConnect(ref v108102adj, "v108114walk", 1, v108102adj.midX + 45, v108101adj.midY);
            this.nodes.Add(v108114walk);
            Vertex v108115adj = Vertex.makeConnect(ref v108115, "v108115adj", 1, v108115.midX, v108101adj.midY);
            this.nodes.Add(v108115adj);
            Vertex v108116adj = Vertex.makeConnect(ref v108116, "v108116adj", 1, v108116.midX, v108101adj.midY);
            this.nodes.Add(v108116adj);
            Vertex v108117adj = Vertex.makeConnect(ref v108117, "v108117adj", 1, v108117.midX, v108101adj.midY);
            this.nodes.Add(v108117adj);
            Vertex v108118adj = Vertex.makeConnect(ref v108118, "v108118adj", 1, v108118.midX, v108101adj.midY);
            this.nodes.Add(v108118adj);

            Vertex v108119adj = Vertex.makeConnect(ref v108119, "v108119adj", 1, v108119.midX, v108101adj.midY);
            this.nodes.Add(v108119adj);
            Vertex v108120adj = Vertex.makeConnect(ref v10812, "v108120adj", 1, v10812.midX, v108101adj.midY);
            this.nodes.Add(v108120adj);
            Vertex v108121adj = Vertex.makeConnect(ref v108121, "v108121adj", 1, v108121.midX, v108101adj.midY);
            this.nodes.Add(v108121adj);
            Vertex v108122adj = Vertex.makeConnect(ref v108122, "v108122adj", 1, v108122.midX, v108101adj.midY);
            this.nodes.Add(v108122adj);
            Vertex v108123adj = Vertex.makeConnect(ref v108123, "v108123adj", 1, v108123.midX, v108101adj.midY);
            this.nodes.Add(v108123adj);
            Vertex v108123walk = Vertex.makeConnect(ref v108123adj, "v108123walk", 1, v1078adj.midX, v108123adj.midY);
            this.nodes.Add(v108123walk);
            

            Vertex v108124 = new Vertex(Int32.MaxValue, "1081.24", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 0, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108125 = new Vertex(Int32.MaxValue, "1081.25", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 1, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108126 = new Vertex(Int32.MaxValue, "1081.26", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 2, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108127 = new Vertex(Int32.MaxValue, "1081.27", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 3, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108128 = new Vertex(Int32.MaxValue, "1081.28", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 4, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108129 = new Vertex(Int32.MaxValue, "1081.29", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 5, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v10813 = new Vertex(Int32.MaxValue, "1081.3", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 6, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108131 = new Vertex(Int32.MaxValue, "1081.31", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 7, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108132 = new Vertex(Int32.MaxValue, "1081.32", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 8, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108133 = new Vertex(Int32.MaxValue, "1081.33", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 9, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108134 = new Vertex(Int32.MaxValue, "1081.34", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 10, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 2 + Constants.FirstFloorSalesWalk, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108124adj = Vertex.makeAdjacent(ref v108124, "v108124adj", 1, "down", 48);
            this.nodes.Add(v108124adj);
            Vertex v108125adj = Vertex.makeConnect(ref v108125, "v108125adj", 1, v108125.midX, v108124adj.midY);
            this.nodes.Add(v108125adj);
            Vertex v108125walk = Vertex.makeConnect(ref v108125adj, "v108125walk", 1, v108114walk.midX, v108125adj.midY);
            this.nodes.Add(v108125walk);
            Vertex v108126adj = Vertex.makeConnect(ref v108126, "v108126adj", 1, v108126.midX, v108124adj.midY);
            this.nodes.Add(v108126adj);
            Vertex v108127adj = Vertex.makeConnect(ref v108127, "v108127adj", 1, v108127.midX, v108124adj.midY);
            this.nodes.Add(v108127adj);
            Vertex v108128adj = Vertex.makeConnect(ref v108128, "v108128adj", 1, v108128.midX, v108124adj.midY);
            this.nodes.Add(v108128adj);
            Vertex v108129adj = Vertex.makeConnect(ref v108129, "v108129adj", 1, v108129.midX, v108124adj.midY);
            this.nodes.Add(v108129adj);
            Vertex v108129walk = Vertex.makeConnect(ref v108129adj, "v108129walk", 1, v108107walk.midX, v108129adj.midY);
            this.nodes.Add(v108129walk);
            Vertex v108130adj = Vertex.makeConnect(ref v10813, "v108130adj", 1, v10813.midX, v108124adj.midY);
            this.nodes.Add(v108130adj);
            Vertex v108131adj = Vertex.makeConnect(ref v108131, "v108131adj", 1, v108131.midX, v108124adj.midY);
            this.nodes.Add(v108131adj);
            Vertex v108132adj = Vertex.makeConnect(ref v108132, "v108132adj", 1, v108132.midX, v108124adj.midY);
            this.nodes.Add(v108132adj);
            Vertex v108133adj = Vertex.makeConnect(ref v108133, "v108133adj", 1, v108133.midX, v108124adj.midY);
            this.nodes.Add(v108133adj);
            Vertex v108134adj = Vertex.makeConnect(ref v108134, "v108134adj", 1, v108134.midX, v108124adj.midY);
            this.nodes.Add(v108134adj);


            Vertex v108135 = new Vertex(Int32.MaxValue, "1081.35", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 0, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108136 = new Vertex(Int32.MaxValue, "1081.36", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 1, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108137 = new Vertex(Int32.MaxValue, "1081.37", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 2, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108138 = new Vertex(Int32.MaxValue, "1081.38", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 3, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108139 = new Vertex(Int32.MaxValue, "1081.39", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 4, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v10814 = new Vertex(Int32.MaxValue, "1081.4", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 5, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108141 = new Vertex(Int32.MaxValue, "1081.41", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 6, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108142 = new Vertex(Int32.MaxValue, "1081.42", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 7, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108143 = new Vertex(Int32.MaxValue, "1081.43", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 8, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108144 = new Vertex(Int32.MaxValue, "1081.44", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 9, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108145 = new Vertex(Int32.MaxValue, "1081.45", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 10, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 3 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);

            Vertex v108146 = new Vertex(Int32.MaxValue, "1081.46", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 0, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108147 = new Vertex(Int32.MaxValue, "1081.47", Constants.Sales108101_56X + Constants.FirstFloorCubicleWidth * 1, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108148 = new Vertex(Int32.MaxValue, "1081.48", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 2, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108149 = new Vertex(Int32.MaxValue, "1081.49", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 3, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v10815 = new Vertex(Int32.MaxValue, "1081.5", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 4, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108151 = new Vertex(Int32.MaxValue, "1081.51", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk + Constants.FirstFloorCubicleWidth * 5, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108152 = new Vertex(Int32.MaxValue, "1081.52", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 6, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108153 = new Vertex(Int32.MaxValue, "1081.53", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 7, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108154 = new Vertex(Int32.MaxValue, "1081.54", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 8, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108155 = new Vertex(Int32.MaxValue, "1081.55", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 9, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108156 = new Vertex(Int32.MaxValue, "1081.56", Constants.Sales108101_56X + Constants.FirstFloorSalesWalk * 2 + Constants.FirstFloorCubicleWidth * 10, Constants.Sales108101_56Y + Constants.FirstFloorCubicleHeight * 4 + Constants.FirstFloorSalesWalk * 2, Constants.FirstFloorCubicleWidth, Constants.FirstFloorCubicleHeight);
            Vertex v108146adj = Vertex.makeAdjacent(ref v108146, "v108146adj", 1, "down", 48);
            this.nodes.Add(v108146adj);
            Vertex v108147adj = Vertex.makeConnect(ref v108147, "v108147adj", 1, v108147.midX, v108146adj.midY);
            this.nodes.Add(v108147adj);
            Vertex v108148adj = Vertex.makeConnect(ref v108148, "v108148adj", 1, v108148.midX, v108146adj.midY);
            this.nodes.Add(v108148adj);
            Vertex v108149adj = Vertex.makeConnect(ref v108149, "v108149adj", 1, v108149.midX, v108146adj.midY);
            this.nodes.Add(v108149adj);
            Vertex v108150adj = Vertex.makeConnect(ref v10815, "v108150adj", 1, v10815.midX, v108146adj.midY);
            this.nodes.Add(v108150adj);
            Vertex v108151adj = Vertex.makeConnect(ref v108151, "v108151adj", 1, v108151.midX, v108146adj.midY);
            this.nodes.Add(v108151adj);
            Vertex v108152adj = Vertex.makeConnect(ref v108152, "v108152adj", 1, v108152.midX, v108146adj.midY);
            this.nodes.Add(v108152adj);
            Vertex v108153adj = Vertex.makeConnect(ref v108153, "v108153adj", 1, v108153.midX, v108146adj.midY);
            this.nodes.Add(v108153adj);
            Vertex v108154adj = Vertex.makeConnect(ref v108154, "v108154adj", 1, v108154.midX, v108146adj.midY);
            this.nodes.Add(v108154adj);
            Vertex v108155adj = Vertex.makeConnect(ref v108155, "v108155adj", 1, v108155.midX, v108146adj.midY);
            this.nodes.Add(v108155adj);
            Vertex v108156adj = Vertex.makeConnect(ref v108156, "v108156adj", 1, v108156.midX, v108146adj.midY);
            this.nodes.Add(v108156adj);
            Vertex v108156walk = Vertex.makeConnect(ref v108156adj, "v108156walk", 1, v1078adj.midX, v108146adj.midY);
            this.nodes.Add(v108156walk);

            //Directors
            Vertex v1068adj = Vertex.makeConnect(ref v1068, "v1068adj", 1, v1068.midX, v108146adj.midY);
            this.nodes.Add(v1068adj);
            Vertex v1069adj = Vertex.makeConnect(ref v1069, "v1069adj", 1, v1069.midX, v108146adj.midY);
            this.nodes.Add(v1069adj);
            Vertex v1070adj = Vertex.makeConnect(ref v1070, "v1070adj", 1, v1070.midX, v108146adj.midY);
            this.nodes.Add(v1070adj);
            Vertex v1071adj = Vertex.makeConnect(ref v1071, "v1071adj", 1, v1071.midX, v108146adj.midY);
            this.nodes.Add(v1071adj);
            Vertex v1072adj = Vertex.makeConnect(ref v1072, "v1072adj", 1, v1072.midX, v108146adj.midY);
            this.nodes.Add(v1072adj);
            Vertex v1073adj = Vertex.makeConnect(ref v1073, "v1073adj", 1, v1073.midX, v108146adj.midY);
            this.nodes.Add(v1073adj);
            Vertex v1074adj = Vertex.makeConnect(ref v1074, "v1074adj", 1, v1074.midX, v108146adj.midY);
            this.nodes.Add(v1074adj);
            Vertex v1075adj = Vertex.makeConnect(ref v1075, "v1075adj", 1, v1075.midX, v108146adj.midY);
            this.nodes.Add(v1075adj);
            Vertex v1076adj = Vertex.makeConnect(ref v1076, "v1076adj", 1, v1076.midX, v108146adj.midY);
            this.nodes.Add(v1076adj);

            Vertex v108147walk = Vertex.makeConnect(ref v108147adj, "v108147walk", 1, v108125walk.midX, v108146adj.midY);
            this.nodes.Add(v108147walk);
            Vertex v108151walk = Vertex.makeConnect(ref v108151adj, "v1081adj", 1, v1055adj.midX, v108151adj.midY);
            this.nodes.Add(v108151walk);
            Vertex v1072walk = Vertex.makeConnect(ref v1072adj, "v1072walk", 1, v108129walk.midX, v1072adj.midY);
            this.nodes.Add(v1072walk);

            Vertex v1049walk = Vertex.makeConnect(ref v1049adj, "v1049walk", 1, v1078adj.midX, v1049adj.midY);
            this.nodes.Add(v1049walk);
            Vertex connectToLobby = Vertex.makeConnect(ref v1002adj, "connectToLobby", 1, v1078adj.midX, v1002adj.midY, 2);
            this.nodes.Add(connectToLobby);


            #region Connect First Floor Cubicles

            Vertex.connectVertex(ref v108101adj, ref v108113);
            Vertex.connectVertex(ref v108102adj, ref v108114);
            Vertex.connectVertex(ref v108101adj, ref v108102adj);
            Vertex.connectVertex(ref v108114walk, ref v108103adj);
            Vertex.connectVertex(ref v108115adj, ref v108103adj);
            Vertex.connectVertex(ref v108115adj, ref v108104adj);
            Vertex.connectVertex(ref v108116adj, ref v108104adj);
            Vertex.connectVertex(ref v108116adj, ref v108105adj);
            Vertex.connectVertex(ref v108117adj, ref v108105adj);
            Vertex.connectVertex(ref v108117adj, ref v108106adj);
            Vertex.connectVertex(ref v108118adj, ref v108106adj);
            Vertex.connectVertex(ref v108118adj, ref v108107adj);
            Vertex.connectVertex(ref v108107walk, ref v108108adj);
            Vertex.connectVertex(ref v108119adj, ref v108108adj);
            Vertex.connectVertex(ref v108119adj, ref v108109adj);
            Vertex.connectVertex(ref v108120adj, ref v108109adj);
            Vertex.connectVertex(ref v108120adj, ref v108110adj);
            Vertex.connectVertex(ref v108121adj, ref v108110adj);
            Vertex.connectVertex(ref v108121adj, ref v108111adj);
            Vertex.connectVertex(ref v108122adj, ref v108111adj);
            Vertex.connectVertex(ref v108122adj, ref v108112adj);
            Vertex.connectVertex(ref v108123adj, ref v108112adj);
            Vertex.connectVertex(ref v108124adj, ref v108135, 1);
            Vertex.connectVertex(ref v108125adj, ref v108136, 1);
            Vertex.connectVertex(ref v108126adj, ref v108137, 1);
            Vertex.connectVertex(ref v108127adj, ref v108138, 1);
            Vertex.connectVertex(ref v108128adj, ref v108139, 1);
            Vertex.connectVertex(ref v108129adj, ref v10814, 1);
            Vertex.connectVertex(ref v108130adj, ref v108141, 1);
            Vertex.connectVertex(ref v108131adj, ref v108142, 1);
            Vertex.connectVertex(ref v108132adj, ref v108143, 1);
            Vertex.connectVertex(ref v108133adj, ref v108144, 1);
            Vertex.connectVertex(ref v108134adj, ref v108145, 1);
            Vertex.connectVertex(ref v108124adj, ref v108125adj, 1);
            Vertex.connectVertex(ref v108126adj, ref v108127adj, 1);
            Vertex.connectVertex(ref v108127adj, ref v108128adj, 1);
            Vertex.connectVertex(ref v108129adj, ref v108128adj, 1);
            Vertex.connectVertex(ref v108130adj, ref v108131adj, 1);
            Vertex.connectVertex(ref v108131adj, ref v108132adj, 1);
            Vertex.connectVertex(ref v108132adj, ref v108133adj, 1);
            Vertex.connectVertex(ref v108133adj, ref v108134adj, 1);
            Vertex.connectVertex(ref v108114walk, ref v108125walk, 1);
            Vertex.connectVertex(ref v108125walk, ref v108126adj, 1);
            Vertex.connectVertex(ref v108129walk, ref v108107walk, 1);
            Vertex.connectVertex(ref v108129walk, ref v108130adj, 1);
            Vertex.connectVertex(ref v108146adj, ref v1066, 1);
            Vertex.connectVertex(ref v108147adj, ref v1067, 1);
            Vertex.connectVertex(ref v108146adj, ref v108147adj, 1);
            Vertex.connectVertex(ref v108147walk, ref v108125walk, 1);
            Vertex.connectVertex(ref v108147walk, ref v1068adj, 1);
            Vertex.connectVertex(ref v108148adj, ref v1068adj, 1);
            Vertex.connectVertex(ref v108148adj, ref v1069adj, 1);
            Vertex.connectVertex(ref v108149adj, ref v1069adj, 1);
            Vertex.connectVertex(ref v108149adj, ref v1070adj, 1);
            Vertex.connectVertex(ref v108150adj, ref v1070adj, 1);
            Vertex.connectVertex(ref v108150adj, ref v1071adj, 1);
            Vertex.connectVertex(ref v108151adj, ref v1071adj, 1);
            Vertex.connectVertex(ref v1055adj, ref v108151walk, 1);
            Vertex.connectVertex(ref v1072walk, ref v108129walk, 1);
            Vertex.connectVertex(ref v1072walk, ref v108151walk, 1);
            Vertex.connectVertex(ref v108152adj, ref v1072adj, 1);
            Vertex.connectVertex(ref v108152adj, ref v1072adj, 1);
            Vertex.connectVertex(ref v108152adj, ref v1073adj, 1);
            Vertex.connectVertex(ref v108153adj, ref v1073adj, 1);
            Vertex.connectVertex(ref v108153adj, ref v1074adj, 1);
            Vertex.connectVertex(ref v108154adj, ref v1074adj, 1);
            Vertex.connectVertex(ref v108154adj, ref v1075adj, 1);
            Vertex.connectVertex(ref v108155adj, ref v1075adj, 1);
            Vertex.connectVertex(ref v108155adj, ref v1076adj, 1);
            Vertex.connectVertex(ref v108156adj, ref v1076adj, 1);
            Vertex.connectVertex(ref v1080adj, ref v108123walk, 1);
            Vertex.connectVertex(ref v108123walk, ref v1079adj, 1);
            Vertex.connectVertex(ref v1079adj, ref v1078adj);
            Vertex.connectVertex(ref v1077walk, ref v108156walk);
            Vertex.connectVertex(ref v108156walk, ref v1077walk2);
            Vertex.connectVertex(ref v1049walk, ref v1077walk2);
            Vertex.connectVertex(ref v1048walk, ref v1049walk);
            Vertex.connectVertex(ref v1046adj, ref v1043adj);
            Vertex.connectVertex(ref v1078adj, ref connectToLobby);
            Vertex.connectVertex(ref connectToLobby, ref v1077walk);
            Vertex.connectVertex(ref connectToLobby, ref v108134adj);
            Vertex.connectVertex(ref v1048walk, ref v1041adj);

            #endregion



            Vertex v1082 = new Vertex(Int32.MaxValue, "1082", 0, 0);
            Vertex v1083 = new Vertex(Int32.MaxValue, "1083", 0, 0);
            Vertex v1086 = new Vertex(Int32.MaxValue, "1086", 0, 0);
            Vertex v1087 = new Vertex(Int32.MaxValue, "1087", 0, 0);
            Vertex v1088 = new Vertex(Int32.MaxValue, "1088", 0, 0);
            Vertex v1089 = new Vertex(Int32.MaxValue, "1089", 0, 0);
            Vertex v1090 = new Vertex(Int32.MaxValue, "1090", 0, 0);
            Vertex v1091 = new Vertex(Int32.MaxValue, "1091", 0, 0);
            Vertex v1092 = new Vertex(Int32.MaxValue, "1092", 0, 0);
            Vertex v1095 = new Vertex(Int32.MaxValue, "1095", 0, 0);
            Vertex v1096 = new Vertex(Int32.MaxValue, "1096", 0, 0);
            Vertex v1097 = new Vertex(Int32.MaxValue, "1097", 0, 0);
            Vertex v1098 = new Vertex(Int32.MaxValue, "1098", 0, 0);
            Vertex v1100 = new Vertex(Int32.MaxValue, "1100", 0, 0);
            Vertex v1101 = new Vertex(Int32.MaxValue, "1101", 0, 0);
            Vertex v110201 = new Vertex(Int32.MaxValue, "1102.01", 0, 0);
            Vertex v110202 = new Vertex(Int32.MaxValue, "1102.02", 0, 0);
            Vertex v110203 = new Vertex(Int32.MaxValue, "1102.03", 0, 0);
            Vertex v110204 = new Vertex(Int32.MaxValue, "1102.04", 0, 0);
            Vertex v1103 = new Vertex(Int32.MaxValue, "1103", 0, 0);
            Vertex v1104 = new Vertex(Int32.MaxValue, "1104", 0, 0);
            Vertex v1105 = new Vertex(Int32.MaxValue, "1105", 0, 0);
            Vertex v110601 = new Vertex(Int32.MaxValue, "1106.01", 0, 0);
            Vertex v110602 = new Vertex(Int32.MaxValue, "1106.02", 0, 0);
            Vertex v110603 = new Vertex(Int32.MaxValue, "1106.03", 0, 0);
            Vertex v110604 = new Vertex(Int32.MaxValue, "1106.04", 0, 0);
            Vertex v110701 = new Vertex(Int32.MaxValue, "1107.01", 0, 0);
            Vertex v110702 = new Vertex(Int32.MaxValue, "1107.02", 0, 0);
            Vertex v110703 = new Vertex(Int32.MaxValue, "1107.03", 0, 0);
            Vertex v110801 = new Vertex(Int32.MaxValue, "1108.01", 0, 0);
            Vertex v110802 = new Vertex(Int32.MaxValue, "1108.02", 0, 0);
            Vertex v1109 = new Vertex(Int32.MaxValue, "1109", 0, 0);
            Vertex v111001 = new Vertex(Int32.MaxValue, "1110.01", 0, 0);
            Vertex v111002 = new Vertex(Int32.MaxValue, "1110.02", 0, 0);
            Vertex v111101 = new Vertex(Int32.MaxValue, "1111.01", 0, 0);
            Vertex v111102 = new Vertex(Int32.MaxValue, "1111.02", 0, 0);
            Vertex v111103 = new Vertex(Int32.MaxValue, "1111.03", 0, 0);
            Vertex v111104 = new Vertex(Int32.MaxValue, "1111.04", 0, 0);
            Vertex v111105 = new Vertex(Int32.MaxValue, "1111.05", 0, 0);
            Vertex v111106 = new Vertex(Int32.MaxValue, "1111.06", 0, 0);
            Vertex v1112 = new Vertex(Int32.MaxValue, "1112", 0, 0);
            Vertex v1113 = new Vertex(Int32.MaxValue, "1113", 0, 0);
            Vertex v111801 = new Vertex(Int32.MaxValue, "1118.01", 0, 0);
            Vertex v111802 = new Vertex(Int32.MaxValue, "1118.02", 0, 0);
            Vertex v111803 = new Vertex(Int32.MaxValue, "1118.03", 0, 0);
            Vertex v111804 = new Vertex(Int32.MaxValue, "1118.04", 0, 0);
            Vertex v111805 = new Vertex(Int32.MaxValue, "1118.05", 0, 0);
            Vertex v1119 = new Vertex(Int32.MaxValue, "1119", 0, 0);
            Vertex v1120 = new Vertex(Int32.MaxValue, "1120", 0, 0);
            Vertex v112001 = new Vertex(Int32.MaxValue, "1120.01", 0, 0);
            Vertex v112101 = new Vertex(Int32.MaxValue, "1121.01", 0, 0);
            Vertex v112102 = new Vertex(Int32.MaxValue, "1121.02", 0, 0);
            Vertex v112103 = new Vertex(Int32.MaxValue, "1121.03", 0, 0);
            Vertex v112104 = new Vertex(Int32.MaxValue, "1121.04", 0, 0);
            Vertex v112105 = new Vertex(Int32.MaxValue, "1121.05", 0, 0);
            Vertex v112106 = new Vertex(Int32.MaxValue, "1121.06", 0, 0);
            Vertex v112107 = new Vertex(Int32.MaxValue, "1121.07", 0, 0);
            Vertex v1123 = new Vertex(Int32.MaxValue, "1123", 0, 0);
            Vertex v1126 = new Vertex(Int32.MaxValue, "1126", 0, 0);
            Vertex v1127 = new Vertex(Int32.MaxValue, "1127", 0, 0);
            Vertex v1128 = new Vertex(Int32.MaxValue, "1128", 0, 0);
            Vertex v1129 = new Vertex(Int32.MaxValue, "1129", 0, 0);
            Vertex v1130 = new Vertex(Int32.MaxValue, "1130", 0, 0);
            Vertex v1131 = new Vertex(Int32.MaxValue, "1131", 0, 0);
            Vertex v1132 = new Vertex(Int32.MaxValue, "1132", 0, 0);
            Vertex v1133 = new Vertex(Int32.MaxValue, "1133", 0, 0);
            Vertex v113301 = new Vertex(Int32.MaxValue, "1133.01", 0, 0);

            #endregion

            #region Make Second Floor 

            

            Vertex v2007 = new Vertex(Int32.MaxValue, "2007", Constants.Room2007X, Constants.Room2007Y, Constants.Room2007Width, Constants.Room2007Height);
            Vertex v2007adj = Vertex.makeAdjacent(ref v2007, "v2007adj", 2, "down", 100);
            this.nodes.Add(v2007adj);

            Vertex v200701 = new Vertex(Int32.MaxValue, "2007.01", 0, 0);
            Vertex v200702 = new Vertex(Int32.MaxValue, "2007.02", 0, 0);
            Vertex v200703 = new Vertex(Int32.MaxValue, "2007.03", 0, 0);
            Vertex v200704 = new Vertex(Int32.MaxValue, "2007.04", 0, 0);
            Vertex v200705 = new Vertex(Int32.MaxValue, "2007.05", 0, 0);
            Vertex v200706 = new Vertex(Int32.MaxValue, "2007.06", 0, 0);
            Vertex v200707 = new Vertex(Int32.MaxValue, "2007.07", 0, 0);
            Vertex v200708 = new Vertex(Int32.MaxValue, "2007.08", 0, 0);
            Vertex v200709 = new Vertex(Int32.MaxValue, "2007.09", 0, 0);
            Vertex v20071 = new Vertex(Int32.MaxValue, "2007.1", 0, 0);
            Vertex v200711 = new Vertex(Int32.MaxValue, "2007.11", 0, 0);
            Vertex v200712 = new Vertex(Int32.MaxValue, "2007.12", 0, 0);
            Vertex v200713 = new Vertex(Int32.MaxValue, "2007.13", 0, 0);
            Vertex v200900 = new Vertex(Int32.MaxValue, "2009.00", Constants.Room2009X, Constants.Room2009Y, Constants.Room2009Width, Constants.Room2009Height);
            Vertex v200900adj = Vertex.makeAdjacent(ref v200900, "v200900adj", 2, "down", 100);
            this.nodes.Add(v200900adj);
            Vertex v200900walk = Vertex.makeAdjacent(ref v200900adj, "v200900walk", 2, "right", 110);
            this.nodes.Add(v200900walk);
            
            Vertex v201000 = new Vertex(Int32.MaxValue, "2010.00", Constants.Room2010X, Constants.Room2010Y, Constants.Room2010Width, Constants.Room2010Height);
            Vertex v2011 = new Vertex(Int32.MaxValue, "2011", Constants.Room2011X, Constants.Room2011Y, Constants.Room2011Width, Constants.Room2011Height);
            Vertex v2012 = new Vertex(Int32.MaxValue, "2012", Constants.SecondFloorBreakroomX, Constants.SecondFloorBreakroomY, Constants.SecondFloorBreakroomWidth, Constants.SecondFloorBreakroomHeight);
            Vertex v2012adj = Vertex.makeAdjacent(ref v2012, "v2012adj", 2, "left", 76);
            this.nodes.Add(v2012adj);
            
            Vertex v2013 = new Vertex(Int32.MaxValue, "2013", 0, 0);
            Vertex v2014 = new Vertex(Int32.MaxValue, "2014", Constants.SalesExecutiveX, Constants.SalesExecutiveY, Constants.ExecutiveOfficeWidth, Constants.ExecutiveOfficeHeight);
            Vertex v2015 = new Vertex(Int32.MaxValue, "2015", Constants.SalesExecutiveX + Constants.ExecutiveOfficeWidth, Constants.SalesExecutiveY, Constants.ExecutiveOfficeWidth, Constants.ExecutiveOfficeHeight);
            Vertex v2016 = new Vertex(Int32.MaxValue, "2016", Constants.SalesExecutiveX + Constants.ExecutiveOfficeWidth * 2, Constants.SalesExecutiveY, Constants.ExecutiveOfficeWidth, Constants.ExecutiveOfficeHeight);
            Vertex v2017 = new Vertex(Int32.MaxValue, "2017", Constants.SalesExecutiveX + Constants.ExecutiveOfficeWidth * 3, Constants.SalesExecutiveY, Constants.ExecutiveOfficeWidth, Constants.ExecutiveOfficeHeight);
            Vertex v2018 = new Vertex(Int32.MaxValue, "2018", Constants.SalesExecutiveX + Constants.ExecutiveOfficeWidth * 4, Constants.SalesExecutiveY, Constants.ExecutiveOfficeWidth, Constants.ExecutiveOfficeHeight);

            Vertex v2014adj = Vertex.makeAdjacent(ref v2014, "v2014adj", 2, "down", 65);
            this.nodes.Add(v2014adj);
            Vertex v2014walk = Vertex.makeAdjacent(ref v2014adj, "v2014walk", 2, "left", 19);
            this.nodes.Add(v2014walk);
            Vertex v2015adj = Vertex.makeAdjacent(ref v2015, "v2015adj", 2, "down", 65);
            this.nodes.Add(v2015adj);
            Vertex v2016adj = Vertex.makeAdjacent(ref v2016, "v2016adj", 2, "down", 65);
            this.nodes.Add(v2016adj);
            Vertex v2017adj = Vertex.makeAdjacent(ref v2017, "v2017adj", 2, "down", 65);
            this.nodes.Add(v2017adj);
            Vertex v2018adj = Vertex.makeAdjacent(ref v2018, "v2018adj", 2, "down", 65);
            this.nodes.Add(v2018adj);
            Vertex v2018walk = Vertex.makeAdjacent(ref v2018adj, "v2018walk", 2, "right", 50);
            this.nodes.Add(v2018walk);

            //Sales West Side
            Vertex v201901 = new Vertex(Int32.MaxValue, "2019.01", Constants.Sales201901_16X + Constants.CubicleWidth * 0, Constants.Sales201901_16Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201902 = new Vertex(Int32.MaxValue, "2019.02", Constants.Sales201901_16X + Constants.CubicleWidth * 1, Constants.Sales201901_16Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201903 = new Vertex(Int32.MaxValue, "2019.03", Constants.Sales201901_16X + Constants.CubicleWidth * 2, Constants.Sales201901_16Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201904 = new Vertex(Int32.MaxValue, "2019.04", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 3, Constants.Sales201901_16Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201905 = new Vertex(Int32.MaxValue, "2019.05", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 4, Constants.Sales201901_16Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201906 = new Vertex(Int32.MaxValue, "2019.06", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 5, Constants.Sales201901_16Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201907 = new Vertex(Int32.MaxValue, "2019.07", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 6, Constants.Sales201901_16Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201908 = new Vertex(Int32.MaxValue, "2019.08", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 7, Constants.Sales201901_16Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201909 = new Vertex(Int32.MaxValue, "2019.09", Constants.Sales201901_16X + Constants.CubicleWidth * 0, Constants.Sales201901_16Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v20191 = new Vertex(Int32.MaxValue, "2019.1", Constants.Sales201901_16X + Constants.CubicleWidth * 1, Constants.Sales201901_16Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201911 = new Vertex(Int32.MaxValue, "2019.11", Constants.Sales201901_16X + Constants.CubicleWidth * 2, Constants.Sales201901_16Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201912 = new Vertex(Int32.MaxValue, "2019.12", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 3, Constants.Sales201901_16Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201913 = new Vertex(Int32.MaxValue, "2019.13", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 4, Constants.Sales201901_16Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201914 = new Vertex(Int32.MaxValue, "2019.14", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 5, Constants.Sales201901_16Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201915 = new Vertex(Int32.MaxValue, "2019.15", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 6, Constants.Sales201901_16Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v201916 = new Vertex(Int32.MaxValue, "2019.16", Constants.Sales201901_16X + Constants.AllianceInBetween + Constants.CubicleWidth * 7, Constants.Sales201901_16Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);

            Vertex v201901adj = Vertex.makeAdjacent(ref v201901, "v201901adj", 2, "up", 35);
            this.nodes.Add(v201901adj);
            Vertex v201902adj = Vertex.makeAdjacent(ref v201902, "v201902adj", 2, "up", 35);
            this.nodes.Add(v201902adj);
            Vertex v201903adj = Vertex.makeAdjacent(ref v201903, "v201903adj", 2, "up", 35);
            this.nodes.Add(v201903adj);
            Vertex v201903walk = Vertex.makeAdjacent(ref v201903adj, "v201903walk", 2, "right", 35);
            this.nodes.Add(v201903walk);
            
            Vertex v201904adj = Vertex.makeAdjacent(ref v201904, "v201904adj", 2, "up", 35);
            this.nodes.Add(v201904adj);
            Vertex v201905adj = Vertex.makeAdjacent(ref v201905, "v201905adj", 2, "up", 35);
            this.nodes.Add(v201905adj);
            Vertex v201906adj = Vertex.makeAdjacent(ref v201906, "v201906adj", 2, "up", 35);
            this.nodes.Add(v201906adj);
            Vertex v201907adj = Vertex.makeAdjacent(ref v201907, "v201907adj", 2, "up", 35);
            this.nodes.Add(v201907adj);
            Vertex v201908adj = Vertex.makeAdjacent(ref v201908, "v201908adj", 2, "up", 35);
            this.nodes.Add(v201908adj);
           
            Vertex v201909adj = Vertex.makeAdjacent(ref v201909, "v201909adj", 2, "down", 35);
            this.nodes.Add(v201909adj);
            Vertex v201909walk = Vertex.makeAdjacent(ref v201909adj, "v201909walk", 2, "left", 48);
            this.nodes.Add(v201909walk);
            Vertex secondfloorLobbyStairs = new Vertex(Int32.MaxValue, "LobbyStairs", 926, Constants.Room2007Y - 110, 310, 110);
            secondfloorLobbyStairs.info = new Person("Lobby Stair", "", "2vlobby", "", "", "Stairs");
            this.nodes.Add(secondfloorLobbyStairs);

            Vertex.connectVertex(ref secondfloorLobbyStairs, ref v1003, 100);

            Vertex secondfloorLobbyStairsadj = Vertex.makeAdjacent(ref secondfloorLobbyStairs, "secondfloorLobbyStairsadj", 2, "left", 2);
            this.nodes.Add(secondfloorLobbyStairsadj);

            Vertex.connectVertex(ref secondfloorLobbyStairsadj, ref v201909walk);
            Vertex vSecondFloorConnectNS = Vertex.makeAdjacent(ref secondfloorLobbyStairsadj, "vSecondFloorConnectNS", 2, "left", 351, 7);
            this.nodes.Add(vSecondFloorConnectNS);

            Vertex v20191adj = Vertex.makeAdjacent(ref v20191, "v20191adj", 2, "down", 35);
            this.nodes.Add(v20191adj);
            Vertex v201911adj = Vertex.makeAdjacent(ref v201911, "v201911adj", 2, "down", 35);
            this.nodes.Add(v201911adj);
            Vertex v201911walk = Vertex.makeAdjacent(ref v201911adj, "v201911walk", 2, "right", 35);
            this.nodes.Add(v201911walk);
            Vertex v201912adj = Vertex.makeAdjacent(ref v201912, "v201912adj", 2, "down", 35);
            this.nodes.Add(v201912adj);
            Vertex v201913adj = Vertex.makeAdjacent(ref v201913, "v201913adj", 2, "down", 35);
            this.nodes.Add(v201913adj);
            Vertex v201914adj = Vertex.makeAdjacent(ref v201914, "v201914adj", 2, "down", 35);
            this.nodes.Add(v201914adj);
            Vertex v201915adj = Vertex.makeAdjacent(ref v201915, "v201915adj", 2, "down", 35);
            this.nodes.Add(v201915adj);
            Vertex v201916adj = Vertex.makeAdjacent(ref v201916, "v201916adj", 2, "down", 35);
            this.nodes.Add(v201916adj);
            
            
            Vertex v2020 = new Vertex(Int32.MaxValue, "2020", Constants.Room2020X, Constants.Room2020Y, Constants.Room2020Width, Constants.Room2020Height);
            Vertex v2020adj = Vertex.makeAdjacent(ref v2020, "v2020adj", 2, "up", 56);
            this.nodes.Add(v2020adj);
           
            Vertex v2021 = new Vertex(Int32.MaxValue, "2021", Constants.Room2021X, Constants.Room2021Y, Constants.Room2021Width, Constants.Room2021Height);
            Vertex v2021adj = Vertex.makeAdjacent(ref v2021, "v2021adj", 2, "up", 56);
            this.nodes.Add(v2021adj);
            Vertex v2022 = new Vertex(Int32.MaxValue, "2022", Constants.SecondFloorNStairsX, Constants.SecondFloorNStairsY, Constants.SecondFloorNStairsWidth, Constants.SecondFloorNStairsHeight);
            Vertex v2022adj = Vertex.makeAdjacent(ref v2022, "v2022adj", 2, "up", 128);
            this.nodes.Add(v2022adj);
            Vertex v2022walk = Vertex.makeAdjacent(ref v2022adj, "v2022adj", 2, "right", 28);
            this.nodes.Add(v2022walk);
            //Connect North Stairs
            Vertex.connectVertex(ref v2022, ref v1015, 100);
            

            #region Connect Trade 
            Vertex.connectVertex(ref v201903walk, ref v201904adj, 1);
            Vertex.connectVertex(ref v201911walk, ref v201912adj, 1);
            Vertex.connectVertex(ref v201911walk, ref v201903walk, 1);
            Vertex.connectVertex(ref v2014adj, ref v201901adj, 1);
            Vertex.connectVertex(ref v201901adj, ref v201902adj, 1);
            Vertex.connectVertex(ref v2015adj, ref v201902adj, 1);
            Vertex.connectVertex(ref v2015adj, ref v201903adj, 1);
            Vertex.connectVertex(ref v2016adj, ref v201904adj, 1);
            Vertex.connectVertex(ref v2016adj, ref v201905adj, 1);
            Vertex.connectVertex(ref v201906adj, ref v201905adj, 1);
            Vertex.connectVertex(ref v201906adj, ref v2017adj, 1);
            Vertex.connectVertex(ref v201907adj, ref v2017adj, 1);
            Vertex.connectVertex(ref v201907adj, ref v201908adj, 1);
            Vertex.connectVertex(ref v2018adj, ref v201908adj, 1);

            Vertex.connectVertex(ref v201909adj, ref v20191adj, 1);
            Vertex.connectVertex(ref v20191adj, ref v2020adj, 1);
            Vertex.connectVertex(ref v201911adj, ref v2020adj, 1);
            Vertex.connectVertex(ref v201911adj, ref v201912adj, 1);
            Vertex.connectVertex(ref v201912adj, ref v2021adj, 1);
            Vertex.connectVertex(ref v201913adj, ref v2021adj, 1);
            Vertex.connectVertex(ref v201913adj, ref v201914adj, 1);
            Vertex.connectVertex(ref v201914adj, ref v201915adj, 1);
            Vertex.connectVertex(ref v201915adj, ref v201916adj, 1);
            Vertex.connectVertex(ref v200900adj, ref v2011, 1);
            Vertex.connectVertex(ref v200900adj, ref v2007adj, 1);
            Vertex.connectVertex(ref v2007adj, ref v201000, 1);
            Vertex.connectVertex(ref v2014walk, ref v201909walk, 1);
            Vertex.connectVertex(ref v2022adj, ref v2021adj, 1);
            Vertex.connectVertex(ref v2022walk, ref v2018adj, 1);
            #endregion


            Vertex v2023 = new Vertex(Int32.MaxValue, "2023", 0, 0);
            Vertex v2024 = new Vertex(Int32.MaxValue, "2024", 0, 0);
            Vertex v2025 = new Vertex(Int32.MaxValue, "2025", 0, 0);

            Vertex northSecondBR = new Vertex(Int32.MaxValue, "northSecondBR", Constants.SecondFloorNBathroomX, Constants.SecondFloorNBathroomY, Constants.SecondFloorNBathRoomWidth, Constants.SecondFloorNBathroomHeight);
            northSecondBR.info = new Person("northSecondBR", "", "2012S", "", "", "");
            this.nodes.Add(northSecondBR);
            Vertex northSecondBRadj = Vertex.makeAdjacent(ref northSecondBR, "northSecondBRadj", 2, "left", 121);
            this.nodes.Add(northSecondBRadj);
            Vertex.connectVertex(ref northSecondBRadj, ref v200900walk, 1);
            Vertex.connectVertex(ref v200900walk, ref v2012adj, 1);
            Vertex.connectVertex(ref v201909walk, ref northSecondBRadj, 1);

            //Sales Cubicles
            Vertex v202601 = new Vertex(Int32.MaxValue, "2026.01", Constants.Sales202601_17X + Constants.CubicleWidth * 0, Constants.Sales202601_17Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202602 = new Vertex(Int32.MaxValue, "2026.02", Constants.Sales202601_17X + Constants.CubicleWidth * 1, Constants.Sales202601_17Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202603 = new Vertex(Int32.MaxValue, "2026.03", Constants.Sales202601_17X + Constants.CubicleWidth * 2, Constants.Sales202601_17Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202604 = new Vertex(Int32.MaxValue, "2026.04", Constants.Sales202601_17X + Constants.CubicleWidth * 3, Constants.Sales202601_17Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202605 = new Vertex(Int32.MaxValue, "2026.05", Constants.Sales202601_17X + Constants.CubicleWidth * 4, Constants.Sales202601_17Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202606 = new Vertex(Int32.MaxValue, "2026.06", Constants.Sales202601_17X + Constants.CubicleWidth * 5, Constants.Sales202601_17Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202601adj = Vertex.makeAdjacent(ref v202601, "v202601adj", 2, "up", 30);
            this.nodes.Add(v202601adj);
            Vertex v202601walk = Vertex.makeAdjacent(ref v202601adj, "v202601walk", 2, "left", 26);
            this.nodes.Add(v202601walk);
            Vertex v202602adj = Vertex.makeAdjacent(ref v202602, "v202602adj", 2, "up", 30);
            this.nodes.Add(v202602adj);
            Vertex v202603adj = Vertex.makeAdjacent(ref v202603, "v202603adj", 2, "up", 30);
            this.nodes.Add(v202603adj);
            Vertex v202604adj = Vertex.makeAdjacent(ref v202604, "v202604adj", 2, "up", 30);
            this.nodes.Add(v202604adj);
            Vertex v202604walk = Vertex.makeAdjacent(ref v202604adj, "v202604walk", 2, "right", 13);
            this.nodes.Add(v202604walk);

            Vertex v202605adj = Vertex.makeAdjacent(ref v202605, "v202605adj", 2, "up", 30);
            this.nodes.Add(v202605adj);
            Vertex v202606adj = Vertex.makeAdjacent(ref v202606, "v202606adj", 2, "up", 30);
            this.nodes.Add(v202606adj);
            Vertex v202606walk = Vertex.makeAdjacent(ref v202606adj, "v202606walk", 2, "right", 77);
            this.nodes.Add(v202606walk);

            Vertex v202607 = new Vertex(Int32.MaxValue, "2026.07", Constants.Sales202601_17X + Constants.CubicleWidth * 0, Constants.Sales202601_17Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202608 = new Vertex(Int32.MaxValue, "2026.08", Constants.Sales202601_17X + Constants.CubicleWidth * 1, Constants.Sales202601_17Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202609 = new Vertex(Int32.MaxValue, "2026.09", Constants.Sales202601_17X + Constants.CubicleWidth * 2, Constants.Sales202601_17Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v20261 = new Vertex(Int32.MaxValue, "2026.1", Constants.Sales202601_17X + Constants.CubicleWidth * 3, Constants.Sales202601_17Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202611 = new Vertex(Int32.MaxValue, "2026.11", Constants.Sales202601_17X + Constants.CubicleWidth * 4, Constants.Sales202601_17Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202612 = new Vertex(Int32.MaxValue, "2026.12", Constants.Sales202601_17X + Constants.CubicleWidth * 5, Constants.Sales202601_17Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202607adj = Vertex.makeAdjacent(ref v202607, "v202607adj", 2, "down", 28);
            this.nodes.Add(v202607adj);
            Vertex v202607walk = Vertex.makeAdjacent(ref v202607adj, "v202607walk", 2, "left", 26);
            this.nodes.Add(v202607walk);
            Vertex v202608adj = Vertex.makeAdjacent(ref v202608, "v202608adj", 2, "down", 28);
            this.nodes.Add(v202608adj);
            Vertex v202609adj = Vertex.makeAdjacent(ref v202609, "v202609adj", 2, "down", 28);
            this.nodes.Add(v202609adj);
            Vertex v20261adj = Vertex.makeAdjacent(ref v20261, "v20261adj", 2, "down", 28);
            this.nodes.Add(v20261adj);
            Vertex v202611adj = Vertex.makeAdjacent(ref v202611, "v202611adj", 2, "down", 28);
            this.nodes.Add(v202611adj);
            Vertex v202612adj = Vertex.makeAdjacent(ref v202612, "v202612adj", 2, "down", 28);
            this.nodes.Add(v202612adj);
            Vertex v202612walk = Vertex.makeAdjacent(ref v202612adj, "v202612walk", 2, "right", 77);
            this.nodes.Add(v202612walk);

            
            Vertex v202613 = new Vertex(Int32.MaxValue, "2026.13", Constants.Sales202601_17X + Constants.CubicleWidth * 1, Constants.Sales202601_17Y + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202614 = new Vertex(Int32.MaxValue, "2026.14", Constants.Sales202601_17X + Constants.CubicleWidth * 2, Constants.Sales202601_17Y + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202615 = new Vertex(Int32.MaxValue, "2026.15", Constants.Sales202601_17X + Constants.CubicleWidth * 3, Constants.Sales202601_17Y + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202616 = new Vertex(Int32.MaxValue, "2026.16", Constants.Sales202601_17X + Constants.CubicleWidth * 4, Constants.Sales202601_17Y + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202617 = new Vertex(Int32.MaxValue, "2026.17", Constants.Sales202601_17X + Constants.CubicleWidth * 5, Constants.Sales202601_17Y + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);

            
            
            #region Connect Sales Cubicles
            Vertex.connectVertex(ref v202601adj, ref v202602adj, 1);
            Vertex.connectVertex(ref v202602adj, ref v202603adj, 1);
            Vertex.connectVertex(ref v202603adj, ref v202604adj, 1);
            Vertex.connectVertex(ref v202604walk, ref v202605adj, 1);
            Vertex.connectVertex(ref v202604walk, ref v201915adj, 1);
            Vertex.connectVertex(ref v202605adj, ref v202606adj, 1);

            Vertex.connectVertex(ref v202607adj, ref v202608adj, 1);
            Vertex.connectVertex(ref v202608adj, ref v202609adj, 1);
            Vertex.connectVertex(ref v202609adj, ref v20261adj, 1);
            Vertex.connectVertex(ref v20261adj, ref v202611adj, 1);
            Vertex.connectVertex(ref v202611adj, ref v202612adj, 1);
            
            Vertex.connectVertex(ref v202608adj, ref v202613, 1);
            Vertex.connectVertex(ref v202609adj, ref v202614, 1);
            Vertex.connectVertex(ref v20261adj, ref v202615, 1);
            Vertex.connectVertex(ref v202611adj, ref v202616, 1);
            Vertex.connectVertex(ref v202612adj, ref v202617, 1);
            Vertex.connectVertex(ref v202601walk, ref v202607walk, 1);

            #endregion


            //Alliance Cubicles
            Vertex v202701 = new Vertex(Int32.MaxValue, "2027.01", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202702 = new Vertex(Int32.MaxValue, "2027.02", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202703 = new Vertex(Int32.MaxValue, "2027.03", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202704 = new Vertex(Int32.MaxValue, "2027.04", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202705 = new Vertex(Int32.MaxValue, "2027.05", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202706 = new Vertex(Int32.MaxValue, "2027.06", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202701adj = Vertex.makeAdjacent(ref v202701, "v202701adj", 2, "down", 45);
            this.nodes.Add(v202701adj);
            Vertex v202701walk = Vertex.makeAdjacent(ref v202701adj, "v202701walk", 2, "left", 45);
            this.nodes.Add(v202701walk);
            Vertex v202702adj = Vertex.makeAdjacent(ref v202702, "v202702adj", 2, "down", 45);
            this.nodes.Add(v202702adj);
            Vertex v202703adj = Vertex.makeAdjacent(ref v202703, "v202703adj", 2, "down", 45);
            this.nodes.Add(v202703adj);
            Vertex v202703walk = Vertex.makeAdjacent(ref v202703adj, "v202703walk", 2, "right", 35);
            this.nodes.Add(v202703walk);
            Vertex v202704adj = Vertex.makeAdjacent(ref v202704, "v202704adj", 2, "down", 45);
            this.nodes.Add(v202704adj);
            Vertex v202705adj = Vertex.makeAdjacent(ref v202705, "v202705adj", 2, "down", 45);
            this.nodes.Add(v202705adj);
            Vertex v202706adj = Vertex.makeAdjacent(ref v202706, "v202706adj", 2, "down", 45);
            this.nodes.Add(v202706adj);
            Vertex v202706walk = Vertex.makeAdjacent(ref v202706adj, "v202706walk", 2, "right", 45);
            this.nodes.Add(v202706walk);

            Vertex v202707 = new Vertex(Int32.MaxValue, "2027.07", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202708 = new Vertex(Int32.MaxValue, "2027.08", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202709 = new Vertex(Int32.MaxValue, "2027.09", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202710 = new Vertex(Int32.MaxValue, "2027.10", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202711 = new Vertex(Int32.MaxValue, "2027.11", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202712 = new Vertex(Int32.MaxValue, "2027.12", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202713 = new Vertex(Int32.MaxValue, "2027.13", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY + Constants.CubicleHeight * 2 + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202714 = new Vertex(Int32.MaxValue, "2027.14", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY + Constants.CubicleHeight * 2 + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202715 = new Vertex(Int32.MaxValue, "2027.15", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY + Constants.CubicleHeight * 2 + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202716 = new Vertex(Int32.MaxValue, "2027.16", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 2 + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202717 = new Vertex(Int32.MaxValue, "2027.17", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 2 + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202718 = new Vertex(Int32.MaxValue, "2027.18", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 2 + Constants.AllianceWalkWidth, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202713adj = Vertex.makeAdjacent(ref v202713, "v202713adj", 2, "down", 45);
            this.nodes.Add(v202713adj);
            Vertex v202713walk = Vertex.makeAdjacent(ref v202713adj, "v202713walk", 2, "left", 45);
            this.nodes.Add(v202713walk);
            Vertex v202713corner = Vertex.makeAdjacent(ref v202713walk, "v202713corner", 2, "up", 48);
            this.nodes.Add(v202713corner);

            Vertex v202714adj = Vertex.makeAdjacent(ref v202714, "v202714adj", 2, "down", 45);
            this.nodes.Add(v202714adj);
            Vertex v202715adj = Vertex.makeAdjacent(ref v202715, "v202715adj", 2, "down", 45);
            this.nodes.Add(v202715adj);
            Vertex v202715walk = Vertex.makeAdjacent(ref v202715adj, "v202715walk", 2, "right", 35);
            this.nodes.Add(v202715walk);
            Vertex v202716adj = Vertex.makeAdjacent(ref v202716, "v202716adj", 2, "down", 45);
            this.nodes.Add(v202716adj);
            Vertex v202717adj = Vertex.makeAdjacent(ref v202717, "v202717adj", 2, "down", 45);
            this.nodes.Add(v202717adj);
            Vertex v202718adj = Vertex.makeAdjacent(ref v202718, "v202718adj", 2, "down", 45);
            this.nodes.Add(v202718adj);
            Vertex v202718walk = Vertex.makeAdjacent(ref v202718adj, "v202718walk", 2, "right", 45);
            this.nodes.Add(v202718walk);


            Vertex v202719 = new Vertex(Int32.MaxValue, "2027.19", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY + Constants.CubicleHeight * 3 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202720 = new Vertex(Int32.MaxValue, "2027.20", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY + Constants.CubicleHeight * 3 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202721 = new Vertex(Int32.MaxValue, "2027.21", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY + Constants.CubicleHeight * 3 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202722 = new Vertex(Int32.MaxValue, "2027.22", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 3 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202723 = new Vertex(Int32.MaxValue, "2027.23", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 3 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202724 = new Vertex(Int32.MaxValue, "2027.24", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 3 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202725 = new Vertex(Int32.MaxValue, "2027.25", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY + Constants.CubicleHeight * 4 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202726 = new Vertex(Int32.MaxValue, "2027.26", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY + Constants.CubicleHeight * 4 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202727 = new Vertex(Int32.MaxValue, "2027.27", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY + Constants.CubicleHeight * 4 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202728 = new Vertex(Int32.MaxValue, "2027.28", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 4 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202729 = new Vertex(Int32.MaxValue, "2027.29", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 4 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202730 = new Vertex(Int32.MaxValue, "2027.30", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 4 + Constants.AllianceWalkWidth * 2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202725adj = Vertex.makeAdjacent(ref v202725, "v202725adj", 2, "down", 45);
            this.nodes.Add(v202725adj);
            Vertex v202725walk = Vertex.makeAdjacent(ref v202725adj, "v202725walk", 2, "left", 45);
            this.nodes.Add(v202725walk);
            Vertex v202726adj = Vertex.makeAdjacent(ref v202726, "v202726adj", 2, "down", 45);
            this.nodes.Add(v202726adj);
            Vertex v202727adj = Vertex.makeAdjacent(ref v202727, "v202727adj", 2, "down", 45);
            this.nodes.Add(v202727adj);
            Vertex v202727walk = Vertex.makeAdjacent(ref v202727adj, "v202727walk", 2, "right", 35);
            this.nodes.Add(v202727walk);
            Vertex v202728adj = Vertex.makeAdjacent(ref v202728, "v202728adj", 2, "down", 45);
            this.nodes.Add(v202728adj);
            Vertex v202729adj = Vertex.makeAdjacent(ref v202729, "v202729adj", 2, "down", 45);
            this.nodes.Add(v202729adj);
            Vertex v202730adj = Vertex.makeAdjacent(ref v202730, "v202730adj", 2, "down", 45);
            this.nodes.Add(v202730adj);
            Vertex v202730walk = Vertex.makeAdjacent(ref v202730adj, "v202730walk", 2, "right", 45);
            this.nodes.Add(v202730walk);

            
            Vertex v202731 = new Vertex(Int32.MaxValue, "2027.31", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY + Constants.CubicleHeight * 5 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202732 = new Vertex(Int32.MaxValue, "2027.32", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY + Constants.CubicleHeight * 5 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202733 = new Vertex(Int32.MaxValue, "2027.33", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY + Constants.CubicleHeight * 5 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202734 = new Vertex(Int32.MaxValue, "2027.34", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 5 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202735 = new Vertex(Int32.MaxValue, "2027.35", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 5 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202736 = new Vertex(Int32.MaxValue, "2027.36", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 5 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202737 = new Vertex(Int32.MaxValue, "2027.37", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY + Constants.CubicleHeight * 6 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202738 = new Vertex(Int32.MaxValue, "2027.38", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY + Constants.CubicleHeight * 6 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202739 = new Vertex(Int32.MaxValue, "2027.39", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY + Constants.CubicleHeight * 6 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202740 = new Vertex(Int32.MaxValue, "2027.40", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 6 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202741 = new Vertex(Int32.MaxValue, "2027.41", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 6 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202742 = new Vertex(Int32.MaxValue, "2027.42", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 6 + Constants.AllianceWalkWidth * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202737adj = Vertex.makeAdjacent(ref v202737, "v202737adj", 2, "down", 45);
            this.nodes.Add(v202737adj);
            Vertex v202737walk = Vertex.makeAdjacent(ref v202737adj, "v202737walk", 2, "left", 45);
            this.nodes.Add(v202737walk);
            Vertex v202738adj = Vertex.makeAdjacent(ref v202738, "v202738adj", 2, "down", 45);
            this.nodes.Add(v202738adj);
            Vertex v202739adj = Vertex.makeAdjacent(ref v202739, "v202739adj", 2, "down", 45);
            this.nodes.Add(v202739adj);
            Vertex v202739walk = Vertex.makeAdjacent(ref v202739adj, "v202739walk", 2, "right", 35);
            this.nodes.Add(v202739walk);
            Vertex v202740adj = Vertex.makeAdjacent(ref v202740, "v202740adj", 2, "down", 45);
            this.nodes.Add(v202740adj);
            Vertex v202741adj = Vertex.makeAdjacent(ref v202741, "v202741adj", 2, "down", 45);
            this.nodes.Add(v202741adj);
            Vertex v202742adj = Vertex.makeAdjacent(ref v202742, "v202742adj", 2, "down", 45);
            this.nodes.Add(v202742adj);
            Vertex v202742walk = Vertex.makeAdjacent(ref v202742adj, "v202742walk", 2, "right", 45);
            this.nodes.Add(v202742walk);


            Vertex v202743 = new Vertex(Int32.MaxValue, "2027.43", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY + Constants.CubicleHeight * 7 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202744 = new Vertex(Int32.MaxValue, "2027.44", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY + Constants.CubicleHeight * 7 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202745 = new Vertex(Int32.MaxValue, "2027.45", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY + Constants.CubicleHeight * 7 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202746 = new Vertex(Int32.MaxValue, "2027.46", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 7 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202747 = new Vertex(Int32.MaxValue, "2027.47", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 7 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202748 = new Vertex(Int32.MaxValue, "2027.48", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 7 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202749 = new Vertex(Int32.MaxValue, "2027.49", Constants.AllianceX + Constants.CubicleWidth * 0, Constants.AllianceY + Constants.CubicleHeight * 8 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202750 = new Vertex(Int32.MaxValue, "2027.50", Constants.AllianceX + Constants.CubicleWidth * 1, Constants.AllianceY + Constants.CubicleHeight * 8 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202751 = new Vertex(Int32.MaxValue, "2027.51", Constants.AllianceX + Constants.CubicleWidth * 2, Constants.AllianceY + Constants.CubicleHeight * 8 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202752 = new Vertex(Int32.MaxValue, "2027.52", Constants.AllianceX + Constants.CubicleWidth * 3 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 8 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202753 = new Vertex(Int32.MaxValue, "2027.53", Constants.AllianceX + Constants.CubicleWidth * 4 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 8 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202754 = new Vertex(Int32.MaxValue, "2027.54", Constants.AllianceX + Constants.CubicleWidth * 5 + Constants.AllianceInBetween, Constants.AllianceY + Constants.CubicleHeight * 8 + Constants.AllianceWalkWidth * 4, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v202749adj = Vertex.makeAdjacent(ref v202749, "v202749adj", 2, "down", 45);
            this.nodes.Add(v202749adj);
            Vertex v202749walk = Vertex.makeAdjacent(ref v202749adj, "v202749walk", 2, "left", 45);
            this.nodes.Add(v202749walk);
            Vertex v202750adj = Vertex.makeAdjacent(ref v202750, "v202750adj", 2, "down", 45);
            this.nodes.Add(v202750adj);
            Vertex v202751adj = Vertex.makeAdjacent(ref v202751, "v202751adj", 2, "down", 45);
            this.nodes.Add(v202751adj);
            Vertex v202751walk = Vertex.makeAdjacent(ref v202751adj, "v202751walk", 2, "right", 35);
            this.nodes.Add(v202751walk);
            Vertex v202752adj = Vertex.makeAdjacent(ref v202752, "v202752adj", 2, "down", 45);
            this.nodes.Add(v202752adj);
            Vertex v202753adj = Vertex.makeAdjacent(ref v202753, "v202753adj", 2, "down", 45);
            this.nodes.Add(v202753adj);
            Vertex v202754adj = Vertex.makeAdjacent(ref v202754, "v202754adj", 2, "down", 45);
            this.nodes.Add(v202754adj);
            Vertex v202754walk = Vertex.makeAdjacent(ref v202754adj, "v202754walk", 2, "right", 45);
            this.nodes.Add(v202754walk);

            #region Connect Alliance Cubicles
            Vertex.connectVertex(ref v202701adj, ref v202707, 1);
            Vertex.connectVertex(ref v202702adj, ref v202708, 1);
            Vertex.connectVertex(ref v202703adj, ref v202709, 1);
            Vertex.connectVertex(ref v202704adj, ref v202710, 1);
            Vertex.connectVertex(ref v202705adj, ref v202711, 1);
            Vertex.connectVertex(ref v202706adj, ref v202712, 1);
            Vertex.connectVertex(ref v202713adj, ref v202719, 1);
            Vertex.connectVertex(ref v202714adj, ref v202720, 1);
            Vertex.connectVertex(ref v202715adj, ref v202721, 1);
            Vertex.connectVertex(ref v202716adj, ref v202722, 1);
            Vertex.connectVertex(ref v202717adj, ref v202723, 1);
            Vertex.connectVertex(ref v202718adj, ref v202724, 1);
            Vertex.connectVertex(ref v202725adj, ref v202731, 1);
            Vertex.connectVertex(ref v202726adj, ref v202732, 1);
            Vertex.connectVertex(ref v202727adj, ref v202733, 1);
            Vertex.connectVertex(ref v202728adj, ref v202734, 1);
            Vertex.connectVertex(ref v202729adj, ref v202735, 1);
            Vertex.connectVertex(ref v202730adj, ref v202736, 1);
            Vertex.connectVertex(ref v202737adj, ref v202743, 1);
            Vertex.connectVertex(ref v202738adj, ref v202744, 1);
            Vertex.connectVertex(ref v202739adj, ref v202745, 1);
            Vertex.connectVertex(ref v202740adj, ref v202746, 1);
            Vertex.connectVertex(ref v202741adj, ref v202747, 1);
            Vertex.connectVertex(ref v202742adj, ref v202748, 1);

            Vertex.connectVertex(ref v202701adj, ref v202702adj, 1);
            Vertex.connectVertex(ref v202702adj, ref v202703adj, 1);
            Vertex.connectVertex(ref v202703walk, ref v202704adj, 1);
            Vertex.connectVertex(ref v202704adj, ref v202705adj, 1);
            Vertex.connectVertex(ref v202705adj, ref v202706adj, 1);
            Vertex.connectVertex(ref v202713adj, ref v202714adj, 1);
            Vertex.connectVertex(ref v202714adj, ref v202715adj, 1);
            Vertex.connectVertex(ref v202715walk, ref v202716adj, 1);
            Vertex.connectVertex(ref v202716adj, ref v202717adj, 1);
            Vertex.connectVertex(ref v202717adj, ref v202718adj, 1);
            Vertex.connectVertex(ref v202725adj, ref v202726adj, 1);
            Vertex.connectVertex(ref v202726adj, ref v202727adj, 1);
            Vertex.connectVertex(ref v202727walk, ref v202728adj, 1);
            Vertex.connectVertex(ref v202728adj, ref v202729adj, 1);
            Vertex.connectVertex(ref v202729adj, ref v202730adj, 1);
            Vertex.connectVertex(ref v202737adj, ref v202738adj, 1);
            Vertex.connectVertex(ref v202738adj, ref v202739adj, 1);
            Vertex.connectVertex(ref v202739walk, ref v202740adj, 1);
            Vertex.connectVertex(ref v202740adj, ref v202741adj, 1);
            Vertex.connectVertex(ref v202741adj, ref v202742adj, 1);
            

            Vertex.connectVertex(ref v202701walk, ref v2018walk, 1);
            Vertex.connectVertex(ref v2022walk, ref v202713corner, 1);
            Vertex.connectVertex(ref v202701walk, ref v202713corner, 1);
            Vertex.connectVertex(ref v202713walk, ref v202725walk, 1);
            Vertex.connectVertex(ref v202606walk, ref v202725walk, 1);
            Vertex.connectVertex(ref v202606walk, ref v202737walk, 1);
            Vertex.connectVertex(ref v202612walk, ref v202737walk, 1);
            Vertex.connectVertex(ref v202612walk, ref v202749walk, 1);

            Vertex.connectVertex(ref v202703walk, ref v202715walk, 1);
            Vertex.connectVertex(ref v202727walk, ref v202715walk, 1);
            Vertex.connectVertex(ref v202739walk, ref v202727walk, 1);
            Vertex.connectVertex(ref v202739walk, ref v202751walk, 1);
            Vertex.connectVertex(ref v202750adj, ref v202749adj, 1);
            Vertex.connectVertex(ref v202750adj, ref v202751adj, 1);
            Vertex.connectVertex(ref v202751walk, ref v202752adj, 1);
            Vertex.connectVertex(ref v202752adj, ref v202753adj, 1);
            Vertex.connectVertex(ref v202753adj, ref v202754adj, 1);

            Vertex.connectVertex(ref v202706walk, ref v202718walk, 1);
            Vertex.connectVertex(ref v202730walk, ref v202718walk, 1);
            Vertex.connectVertex(ref v202730walk, ref v202742walk, 1);
            Vertex.connectVertex(ref v202754walk, ref v202742walk, 1);

            #endregion


            //Sales Directors
            Vertex v2028 = new Vertex(Int32.MaxValue, "2028", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY - Constants.SalesDirectorsW * 7 - 159, Constants.SalesDirectorH, 159);
            Vertex v2029 = new Vertex(Int32.MaxValue, "2029", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY - Constants.SalesDirectorsW * 7, Constants.SalesDirectorH, Constants.SalesDirectorsW);
            Vertex v2030 = new Vertex(Int32.MaxValue, "2030", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY - Constants.SalesDirectorsW * 6, Constants.SalesDirectorH, Constants.SalesDirectorsW);
            Vertex v2031 = new Vertex(Int32.MaxValue, "2031", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY - Constants.SalesDirectorsW * 5, Constants.SalesDirectorH, Constants.SalesDirectorsW);
            Vertex v2032 = new Vertex(Int32.MaxValue, "2032", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY - Constants.SalesDirectorsW * 4, Constants.SalesDirectorH, Constants.SalesDirectorsW);
            Vertex v2033 = new Vertex(Int32.MaxValue, "2033", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY - Constants.SalesDirectorsW * 3, Constants.SalesDirectorH, Constants.SalesDirectorsW);
            Vertex v2034 = new Vertex(Int32.MaxValue, "2034", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY - Constants.SalesDirectorsW * 2, Constants.SalesDirectorH, Constants.SalesDirectorsW);
            Vertex v2035 = new Vertex(Int32.MaxValue, "2035", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY - Constants.SalesDirectorsW, Constants.SalesDirectorH, Constants.SalesDirectorsW);
            Vertex v2036 = new Vertex(Int32.MaxValue, "2036", Constants.SalesDirectorNorthX, Constants.SalesDirectorNorthY, Constants.SalesDirectorH, Constants.SalesDirectorsW);
            Vertex v2037 = new Vertex(Int32.MaxValue, "2037", Constants.SalesDirectorX + Constants.SalesConferenceRoomW + Constants.SalesDirectorsW * 16, Constants.SalesDirectorY, Constants.SalesConferenceRoomW, Constants.SalesConferenceRoomH);
            Vertex v2038 = new Vertex(Int32.MaxValue, "2038", Constants.SalesDirectorX + Constants.SalesConferenceRoomW + Constants.SalesDirectorsW * 15, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2039 = new Vertex(Int32.MaxValue, "2039", Constants.SalesDirectorX + Constants.SalesConferenceRoomW + Constants.SalesDirectorsW * 14, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2040 = new Vertex(Int32.MaxValue, "2040", Constants.SalesDirectorX + Constants.SalesConferenceRoomW + Constants.SalesDirectorsW * 13, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2041 = new Vertex(Int32.MaxValue, "2041", Constants.SalesDirectorX + Constants.SalesConferenceRoomW + Constants.SalesDirectorsW * 12, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2042 = new Vertex(Int32.MaxValue, "2042", Constants.SalesDirectorX + Constants.SalesConferenceRoomW + Constants.SalesDirectorsW * 11, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2043 = new Vertex(Int32.MaxValue, "2043", Constants.SalesDirectorX + Constants.SalesDirectorsW * 11, Constants.SalesDirectorY, Constants.SalesConferenceRoomW, Constants.SalesConferenceRoomH);
            Vertex v2044 = new Vertex(Int32.MaxValue, "2044", Constants.SalesDirectorX + Constants.SalesDirectorsW * 10, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2045 = new Vertex(Int32.MaxValue, "2045", Constants.SalesDirectorX + Constants.SalesDirectorsW * 9, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2046 = new Vertex(Int32.MaxValue, "2046", Constants.SalesDirectorX + Constants.SalesDirectorsW * 8, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2047 = new Vertex(Int32.MaxValue, "2047", Constants.SalesDirectorX + Constants.SalesDirectorsW * 7, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2048 = new Vertex(Int32.MaxValue, "2048", Constants.SalesDirectorX + Constants.SalesDirectorsW * 6, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2049 = new Vertex(Int32.MaxValue, "2049", Constants.SalesDirectorX + Constants.SalesDirectorsW * 5, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2050 = new Vertex(Int32.MaxValue, "2050", Constants.SalesDirectorX + Constants.SalesDirectorsW * 4, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2051 = new Vertex(Int32.MaxValue, "2051", Constants.SalesDirectorX + Constants.SalesDirectorsW * 3, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2052 = new Vertex(Int32.MaxValue, "2052", Constants.SalesDirectorX + Constants.SalesDirectorsW * 2, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2053 = new Vertex(Int32.MaxValue, "2053", Constants.SalesDirectorX + Constants.SalesDirectorsW * 1, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);
            Vertex v2054 = new Vertex(Int32.MaxValue, "2054", Constants.SalesDirectorX + Constants.SalesDirectorsW * 0, Constants.SalesDirectorY, Constants.SalesDirectorsW, Constants.SalesDirectorH);

            Vertex v2028adj = Vertex.makeAdjacent(ref v2028, "v2028adj", 2, "left", 61);
            this.nodes.Add(v2028adj);
            Vertex v2029adj = Vertex.makeAdjacent(ref v2029, "v2029adj", 2, "left", 61);
            this.nodes.Add(v2029adj);
            Vertex v2030adj = Vertex.makeAdjacent(ref v2030, "v2030adj", 2, "left", 61);
            this.nodes.Add(v2030adj);
            Vertex v2031adj = Vertex.makeAdjacent(ref v2031, "v2031adj", 2, "left", 61);
            this.nodes.Add(v2031adj);
            Vertex v2032adj = Vertex.makeAdjacent(ref v2032, "v2032adj", 2, "left", 61);
            this.nodes.Add(v2032adj);
            Vertex v2033adj = Vertex.makeAdjacent(ref v2033, "v2033adj", 2, "left", 61);
            this.nodes.Add(v2033adj);
            Vertex v2034adj = Vertex.makeAdjacent(ref v2034, "v2034adj", 2, "left", 61);
            this.nodes.Add(v2034adj);
            Vertex v2035adj = Vertex.makeAdjacent(ref v2035, "v2035adj", 2, "left", 61);
            this.nodes.Add(v2035adj);
            Vertex v2036adj = Vertex.makeAdjacent(ref v2036, "v2036adj", 2, "left", 61);
            this.nodes.Add(v2036adj);
            Vertex v2037adj = Vertex.makeAdjacent(ref v2037, "v2037adj", 2, "left", 53);
            this.nodes.Add(v2037adj);
            Vertex v2037walk = Vertex.makeAdjacent(ref v2037adj, "v2037walk", 2, "up", 66);
            this.nodes.Add(v2037walk);
            
            Vertex v2038adj = Vertex.makeAdjacent(ref v2038, "v2038adj", 2, "up", 66);
            this.nodes.Add(v2038adj);
            
            
            Vertex v2039adj = Vertex.makeAdjacent(ref v2039, "v2039adj", 2, "up", 66);
            this.nodes.Add(v2039adj);
            
            Vertex v2040adj = Vertex.makeAdjacent(ref v2040, "v2040adj", 2, "up", 66);
            this.nodes.Add(v2040adj);
            
            
            Vertex v2041adj = Vertex.makeAdjacent(ref v2041, "v2041adj", 2, "up", 66);
            this.nodes.Add(v2041adj);
            
            
            Vertex v2042adj = Vertex.makeAdjacent(ref v2042, "v2042adj", 2, "up", 66);
            this.nodes.Add(v2042adj);
            
            
            Vertex v2043adj = Vertex.makeAdjacent(ref v2043, "v2043adj", 2, "up", 66);
            this.nodes.Add(v2043adj);
            Vertex v2043walk = Vertex.makeAdjacent(ref v2043adj, "v2043walk", 2, "up", 43);
            this.nodes.Add(v2043walk);
            Vertex v2044adj = Vertex.makeAdjacent(ref v2044, "v2044adj", 2, "up", 66);
            this.nodes.Add(v2044adj);
            Vertex v2045adj = Vertex.makeAdjacent(ref v2045, "v2045adj", 2, "up", 66);
            this.nodes.Add(v2045adj);
            Vertex v2046adj = Vertex.makeAdjacent(ref v2046, "v2046adj", 2, "up", 66);
            this.nodes.Add(v2046adj);
            Vertex v2046walk = Vertex.makeAdjacent(ref v2046adj, "v2046walk", 2, "left", 38);
            this.nodes.Add(v2046walk);

            Vertex v2047adj = Vertex.makeAdjacent(ref v2047, "v2047adj", 2, "up", 66);
            this.nodes.Add(v2047adj);
            Vertex v2048adj = Vertex.makeAdjacent(ref v2048, "v2048adj", 2, "up", 66);
            this.nodes.Add(v2048adj);
            Vertex v2049adj = Vertex.makeAdjacent(ref v2049, "v2049adj", 2, "up", 66);
            this.nodes.Add(v2049adj);
            Vertex v2050adj = Vertex.makeAdjacent(ref v2050, "v2050adj", 2, "up", 66);
            this.nodes.Add(v2050adj);
            Vertex v2051adj = Vertex.makeAdjacent(ref v2051, "v2051adj", 2, "up", 66);
            this.nodes.Add(v2051adj);
            Vertex v2052adj = Vertex.makeAdjacent(ref v2052, "v2052adj", 2, "up", 66);
            this.nodes.Add(v2052adj);
            Vertex v2053adj = Vertex.makeAdjacent(ref v2053, "v2053adj", 2, "up", 66);
            this.nodes.Add(v2053adj);
            Vertex v2054adj = Vertex.makeAdjacent(ref v2054, "v2054adj", 2, "up", 66);
            this.nodes.Add(v2054adj);

            #region Connect Sales Directors
            Vertex.connectVertex(ref v2028adj, ref v2029adj, 1);
            Vertex.connectVertex(ref v2029adj, ref v2030adj, 1);
            Vertex.connectVertex(ref v2030adj, ref v2031adj, 1);
            Vertex.connectVertex(ref v2031adj, ref v2032adj, 1);
            Vertex.connectVertex(ref v2032adj, ref v2033adj, 1);
            Vertex.connectVertex(ref v2033adj, ref v2034adj, 1);
            Vertex.connectVertex(ref v2034adj, ref v2035adj, 1);
            Vertex.connectVertex(ref v2035adj, ref v2036adj, 1);
            Vertex.connectVertex(ref v2037walk, ref v2036adj, 1);
            Vertex.connectVertex(ref v2037walk, ref v2038adj, 1);
            Vertex.connectVertex(ref v2039adj, ref v2038adj, 1);
            Vertex.connectVertex(ref v2040adj, ref v2039adj, 1);
            Vertex.connectVertex(ref v2041adj, ref v2040adj, 1);
            Vertex.connectVertex(ref v2042adj, ref v2041adj, 1);
            Vertex.connectVertex(ref v2043adj, ref v2042adj, 1);
            Vertex.connectVertex(ref v2044adj, ref v2043adj, 1);
            Vertex.connectVertex(ref v2045adj, ref v2044adj, 1);
            Vertex.connectVertex(ref v2046adj, ref v2045adj, 1);
            Vertex.connectVertex(ref v2047adj, ref v2046walk, 1);
            Vertex.connectVertex(ref v202607walk, ref v2046walk, 1);
            Vertex.connectVertex(ref v2048adj, ref v2047adj, 1);
            Vertex.connectVertex(ref v2049adj, ref v2048adj, 1);
            Vertex.connectVertex(ref v2050adj, ref v2049adj, 1);
            Vertex.connectVertex(ref v2051adj, ref v2050adj, 1);
            Vertex.connectVertex(ref v2052adj, ref v2051adj, 1);
            Vertex.connectVertex(ref v2053adj, ref v2052adj, 1);
            Vertex.connectVertex(ref v2054adj, ref v2053adj, 1);
            Vertex.connectVertex(ref v2012adj, ref v2049adj, 1);

            Vertex.connectVertex(ref v2042adj, ref v202749adj, 1);
            Vertex.connectVertex(ref v2041adj, ref v202751adj, 1);
            Vertex.connectVertex(ref v2040adj, ref v202752adj, 1);
            Vertex.connectVertex(ref v2039adj, ref v202754adj, 1);
            Vertex.connectVertex(ref v2038adj, ref v202754walk, 1);
            Vertex.connectVertex(ref v2035adj, ref v202754walk, 1);
            Vertex.connectVertex(ref v2034adj, ref v202742walk, 1);
            Vertex.connectVertex(ref v2033adj, ref v202742walk, 1);
            Vertex.connectVertex(ref v2032adj, ref v202730walk, 1);
            Vertex.connectVertex(ref v2031adj, ref v202730walk, 1);
            Vertex.connectVertex(ref v2030adj, ref v202718walk, 1);
            Vertex.connectVertex(ref v2029adj, ref v202718walk, 1);
            Vertex.connectVertex(ref v2028adj, ref v202706walk, 1);
            //connect directors to cubes
            

            Vertex.connectVertex(ref v202749walk, ref v2043walk, 1);

            #endregion


            //Finance Cubicles
            Vertex v205601 = new Vertex(Int32.MaxValue, "2056.01", Constants.IT205601_14OddX, Constants.IT205601_14Y, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205602 = new Vertex(Int32.MaxValue, "2056.02", Constants.IT205601_14EvenX, Constants.IT205601_14Y, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205603 = new Vertex(Int32.MaxValue, "2056.03", Constants.IT205601_14OddX, Constants.IT205601_14Y + Constants.TripletHeight, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205604 = new Vertex(Int32.MaxValue, "2056.04", Constants.IT205601_14EvenX, Constants.IT205601_14Y + Constants.TripletHeight, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205605 = new Vertex(Int32.MaxValue, "2056.05", Constants.IT205601_14OddX, Constants.IT205601_14Y + Constants.TripletHeight*2, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205606 = new Vertex(Int32.MaxValue, "2056.06", Constants.IT205601_14EvenX, Constants.IT205601_14Y + Constants.TripletHeight*2, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205607 = new Vertex(Int32.MaxValue, "2056.07", Constants.IT205601_14OddX, Constants.IT205601_14Y + Constants.TripletHeight*3, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205608 = new Vertex(Int32.MaxValue, "2056.08", Constants.IT205601_14EvenX, Constants.IT205601_14Y + Constants.TripletHeight*3, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205609 = new Vertex(Int32.MaxValue, "2056.09", Constants.IT205601_14OddX, Constants.IT205601_14Y + Constants.TripletHeight*4, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v20561 = new Vertex(Int32.MaxValue, "2056.1", Constants.IT205601_14EvenX, Constants.IT205601_14Y + Constants.TripletHeight*4, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205611 = new Vertex(Int32.MaxValue, "2056.11", Constants.IT205601_14OddX, Constants.IT205601_14Y + Constants.TripletHeight*5, Constants.CubicleWidth, Constants.TripletHeight);
            Vertex v205612 = new Vertex(Int32.MaxValue, "2056.12", Constants.IT205601_14EvenX, Constants.IT205601_14Y + Constants.TripletHeight*5, Constants.CubicleWidth, Constants.TripletHeight);            
            Vertex v205613 = new Vertex(Int32.MaxValue, "2056.13", Constants.IT205601_14OddX, Constants.IT205601_14Y + Constants.TripletHeight*6, Constants.CubicleWidth, Constants.ITCubicleSmallHeight);
            Vertex v205614 = new Vertex(Int32.MaxValue, "2056.14", Constants.IT205601_14EvenX, Constants.IT205601_14Y + Constants.TripletHeight*6, Constants.CubicleWidth, Constants.ITCubicleSmallHeight);

            Vertex v205601adj = Vertex.makeAdjacent(ref v205601, "v205601adj", 2, "right", 32);
            this.nodes.Add(v205601adj);
            Vertex v205603adj = Vertex.makeAdjacent(ref v205603, "v205603adj", 2, "right", 32);
            this.nodes.Add(v205603adj);
            Vertex v205605adj = Vertex.makeAdjacent(ref v205605, "v205605adj", 2, "right", 32);
            this.nodes.Add(v205605adj);
            Vertex v205607adj = Vertex.makeAdjacent(ref v205607, "v205607adj", 2, "right", 32);
            this.nodes.Add(v205607adj);
            Vertex v205609adj = Vertex.makeAdjacent(ref v205609, "v205609adj", 2, "right", 32);
            this.nodes.Add(v205609adj);
            Vertex v205611adj = Vertex.makeAdjacent(ref v205611, "v205611adj", 2, "right", 32);
            this.nodes.Add(v205611adj);
            Vertex v205613adj = Vertex.makeAdjacent(ref v205613, "v205613adj", 2, "right", 32);
            this.nodes.Add(v205613adj);
            Vertex v205613walk = Vertex.makeAdjacent(ref v205613adj, "v205613walk", 2, "down", 25);
            this.nodes.Add(v205613walk);

            #region Connect vertices Finance
            Vertex.connectVertex(ref v205601adj, ref v205602, 1);
            Vertex.connectVertex(ref v205603adj, ref v205604, 1);
            Vertex.connectVertex(ref v205605adj, ref v205606, 1);
            Vertex.connectVertex(ref v205607adj, ref v205608, 1);
            Vertex.connectVertex(ref v205609adj, ref v20561, 1);
            Vertex.connectVertex(ref v205611adj, ref v205612, 1);
            Vertex.connectVertex(ref v205613adj, ref v205614, 1);
            Vertex.connectVertex(ref v205601adj, ref v205603adj, 1);
            Vertex.connectVertex(ref v205603adj, ref v205605adj, 1);
            Vertex.connectVertex(ref v205605adj, ref v205607adj, 1);
            Vertex.connectVertex(ref v205607adj, ref v205609adj, 1);
            Vertex.connectVertex(ref v205609adj, ref v205611adj, 1);
            Vertex.connectVertex(ref v205611adj, ref v205613adj, 1);
            
            #endregion


            //IT Cubicles
            Vertex v205615 = new Vertex(Int32.MaxValue, "2056.15", Constants.IT205615_60X, Constants.IT2056015_25Y, Constants.TripletWidth, Constants.CubicleHeight);
            Vertex v205615adj = Vertex.makeAdjacent(ref v205615, "v205615adj", 2, "down", 36);
            this.nodes.Add(v205615adj);
            
            Vertex v205616 = new Vertex(Int32.MaxValue, "2056.16", Constants.IT205615_60X + Constants.TripletWidth, Constants.IT2056015_25Y, Constants.TripletWidth, Constants.CubicleHeight);
            Vertex v205616adj = Vertex.makeAdjacent(ref v205616, "v205616adj", 2, "down", 36);
            this.nodes.Add(v205616adj);
            
            Vertex v205617 = new Vertex(Int32.MaxValue, "2056.17", Constants.IT205615_60X + Constants.TripletWidth * 2, Constants.IT2056015_25Y, Constants.TripletWidth, Constants.CubicleHeight);
            Vertex v205617adj = Vertex.makeAdjacent(ref v205617, "v205617adj", 2, "down", 36);
            this.nodes.Add(v205617adj);
            
            Vertex v205618 = new Vertex(Int32.MaxValue, "2056.18", Constants.IT205615_60X + Constants.CubicleWidth * 4 + 35, Constants.IT2056015_25Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205619 = new Vertex(Int32.MaxValue, "2056.19", Constants.IT205615_60X + Constants.CubicleWidth * 5 + 35, Constants.IT2056015_25Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v20562 = new Vertex(Int32.MaxValue, "2056.2", Constants.IT205615_60X + Constants.CubicleWidth * 6 + 35, Constants.IT2056015_25Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205621 = new Vertex(Int32.MaxValue, "2056.21", Constants.IT205615_60X + Constants.CubicleWidth * 7 + 35, Constants.IT2056015_25Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205622 = new Vertex(Int32.MaxValue, "2056.22", Constants.IT205615_60X + Constants.CubicleWidth * 8 + 70, Constants.IT2056015_25Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205623 = new Vertex(Int32.MaxValue, "2056.23", Constants.IT205615_60X + Constants.CubicleWidth * 9 + 70, Constants.IT2056015_25Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205624 = new Vertex(Int32.MaxValue, "2056.24", Constants.IT205615_60X + Constants.CubicleWidth * 10 + 70, Constants.IT2056015_25Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205625 = new Vertex(Int32.MaxValue, "2056.25", Constants.IT205615_60X + Constants.CubicleWidth * 11 + 70, Constants.IT2056015_25Y, Constants.CubicleWidth, Constants.CubicleHeight);
            
            Vertex v205626 = new Vertex(Int32.MaxValue, "2056.26", Constants.IT205615_60X, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205626adj = Vertex.makeAdjacent(ref v205626, "v205626adj", 2, "up", 35);
            this.nodes.Add(v205626adj);
            Vertex v205626walk = Vertex.makeAdjacent(ref v205626adj, "v205626walk", 2, "left", 35);
            this.nodes.Add(v205626walk);
            
            Vertex v205627 = new Vertex(Int32.MaxValue, "2056.27", Constants.IT205615_60X + Constants.CubicleWidth, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205627adj = Vertex.makeAdjacent(ref v205627, "v205627adj", 2, "up", 35);
            this.nodes.Add(v205627adj);
            
            Vertex v205628 = new Vertex(Int32.MaxValue, "2056.28", Constants.IT205615_60X + Constants.CubicleWidth*2, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205628adj = Vertex.makeAdjacent(ref v205628, "v205628adj", 2, "up", 35);
            this.nodes.Add(v205628adj);
            
            Vertex v205629 = new Vertex(Int32.MaxValue, "2056.29", Constants.IT205615_60X + Constants.CubicleWidth*3, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205629adj = Vertex.makeAdjacent(ref v205629, "v205629adj", 2, "up", 35);
            this.nodes.Add(v205629adj);

            Vertex v205629walk = Vertex.makeAdjacent(ref v205629adj, "v205629walk", 2, "right", 35);
            this.nodes.Add(v205629walk);

            Vertex v20563 = new Vertex(Int32.MaxValue, "2056.3", Constants.IT205615_60X + Constants.CubicleWidth * 4 + 35, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v20563adj = Vertex.makeAdjacent(ref v20563, "v20563adj", 2, "up", 35);
            this.nodes.Add(v20563adj);
            
            Vertex v205631 = new Vertex(Int32.MaxValue, "2056.31", Constants.IT205615_60X + Constants.CubicleWidth * 5 + 35, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205631adj = Vertex.makeAdjacent(ref v205631, "v205631adj", 2, "up", 35);
            this.nodes.Add(v205631adj);
            
            Vertex v205632 = new Vertex(Int32.MaxValue, "2056.32", Constants.IT205615_60X + Constants.CubicleWidth * 6 + 35, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205632adj = Vertex.makeAdjacent(ref v205632, "v205632adj", 2, "up", 35);
            this.nodes.Add(v205632adj);
            
            Vertex v205633 = new Vertex(Int32.MaxValue, "2056.33", Constants.IT205615_60X + Constants.CubicleWidth * 7 + 35, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205633adj = Vertex.makeAdjacent(ref v205633, "v205633adj", 2, "up", 35);
            this.nodes.Add(v205633adj);
            Vertex v205633walk = Vertex.makeAdjacent(ref v205633adj, "v205633walk", 2, "right", 35);
            this.nodes.Add(v205633walk);
            
            Vertex v205634 = new Vertex(Int32.MaxValue, "2056.34", Constants.IT205615_60X + Constants.CubicleWidth * 8 + 70, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205634adj = Vertex.makeAdjacent(ref v205634, "v205634adj", 2, "up", 35);
            this.nodes.Add(v205634adj);
            
            Vertex v205635 = new Vertex(Int32.MaxValue, "2056.35", Constants.IT205615_60X + Constants.CubicleWidth * 9 + 70, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205635adj = Vertex.makeAdjacent(ref v205635, "v205635adj", 2, "up", 35);
            this.nodes.Add(v205635adj);
            
            Vertex v205636 = new Vertex(Int32.MaxValue, "2056.36", Constants.IT205615_60X + Constants.CubicleWidth * 10 + 70, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205636adj = Vertex.makeAdjacent(ref v205636, "v205636adj", 2, "up", 35);
            this.nodes.Add(v205636adj);
            
            Vertex v205637 = new Vertex(Int32.MaxValue, "2056.37", Constants.IT205615_60X + Constants.CubicleWidth * 11 + 70, Constants.IT205626_37Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205637adj = Vertex.makeAdjacent(ref v205637, "v205637adj", 2, "up", 35);
            this.nodes.Add(v205637adj);
            Vertex v205637walk = Vertex.makeAdjacent(ref v205637adj, "v205637walk", 2, "right", 35);
            this.nodes.Add(v205637walk);

            Vertex v205638 = new Vertex(Int32.MaxValue, "2056.38", Constants.IT205615_60X, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205638adj = Vertex.makeAdjacent(ref v205638, "v205638adj", 2, "down", 35);
            this.nodes.Add(v205638adj);
            Vertex v205638walk = Vertex.makeAdjacent(ref v205638adj, "v205638walk", 2, "left", 35);
            this.nodes.Add(v205638walk);


            Vertex v205639 = new Vertex(Int32.MaxValue, "2056.39", Constants.IT205615_60X + Constants.CubicleWidth, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205639adj = Vertex.makeAdjacent(ref v205639, "v205639adj", 2, "down", 35);
            this.nodes.Add(v205639adj);


            Vertex v20564 = new Vertex(Int32.MaxValue, "2056.4", Constants.IT205615_60X + Constants.CubicleWidth * 2, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v20564adj = Vertex.makeAdjacent(ref v20564, "v20564adj", 2, "down", 35);
            this.nodes.Add(v20564adj);



            Vertex v205641 = new Vertex(Int32.MaxValue, "2056.41", Constants.IT205615_60X + Constants.CubicleWidth * 3, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205641adj = Vertex.makeAdjacent(ref v205641, "v205641adj", 2, "down", 35);
            Vertex v205641walk = Vertex.makeAdjacent(ref v205641adj, "v205641walk" , 2, "right", 35);
            this.nodes.Add(v205641walk);
            this.nodes.Add(v205641adj);
            

            Vertex v205642 = new Vertex(Int32.MaxValue, "2056.42", Constants.IT205615_60X + Constants.CubicleWidth * 4 + 35, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205642adj = Vertex.makeAdjacent(ref v205642, "v205642adj", 2, "down", 35);
            this.nodes.Add(v205642adj);
            
            Vertex v205643 = new Vertex(Int32.MaxValue, "2056.43", Constants.IT205615_60X + Constants.CubicleWidth * 5 + 35, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205643adj = Vertex.makeAdjacent(ref v205643, "v205643adj", 2, "down", 35);
            this.nodes.Add(v205643adj);
            
            Vertex v205644 = new Vertex(Int32.MaxValue, "2056.44", Constants.IT205615_60X + Constants.CubicleWidth * 6 + 35, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205644adj = Vertex.makeAdjacent(ref v205644, "v205644adj", 2, "down", 35);
            this.nodes.Add(v205644adj);
            
            Vertex v205645 = new Vertex(Int32.MaxValue, "2056.45", Constants.IT205615_60X + Constants.CubicleWidth * 7 + 35, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205645adj = Vertex.makeAdjacent(ref v205645, "v205645adj", 2, "down", 35);
            this.nodes.Add(v205645adj);
            Vertex v205645walk = Vertex.makeAdjacent(ref v205645adj, "v205645walk", 2, "right", 35);
            this.nodes.Add(v205645walk);
            
            Vertex v205646 = new Vertex(Int32.MaxValue, "2056.46", Constants.IT205615_60X + Constants.CubicleWidth * 8 + 70, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205646adj = Vertex.makeAdjacent(ref v205646, "v205646adj", 2, "down", 35);
            this.nodes.Add(v205646adj);
            
            Vertex v205647 = new Vertex(Int32.MaxValue, "2056.47", Constants.IT205615_60X + Constants.CubicleWidth * 9 + 70, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205647adj = Vertex.makeAdjacent(ref v205647, "v205647adj", 2, "down", 35);
            this.nodes.Add(v205647adj);
            
            
            Vertex v205648 = new Vertex(Int32.MaxValue, "2056.48", Constants.IT205615_60X + Constants.CubicleWidth * 10 + 70, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205648adj = Vertex.makeAdjacent(ref v205648, "v205648adj", 2, "down", 35);
            this.nodes.Add(v205648adj);
            
            Vertex v205649 = new Vertex(Int32.MaxValue, "2056.49", Constants.IT205615_60X + Constants.CubicleWidth * 11 + 70, Constants.IT205638_49Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205649adj = Vertex.makeAdjacent(ref v205649, "v205649adj", 2, "down", 35);
            this.nodes.Add(v205649adj);
            Vertex v205649walk = Vertex.makeAdjacent(ref v205649adj, "v205649walk", 2, "right", 35);
            this.nodes.Add(v205649walk);
      
            Vertex v20565 = new Vertex(Int32.MaxValue, "2056.5", Constants.IT205615_60X, Constants.IT204550_60Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205651 = new Vertex(Int32.MaxValue, "2056.51", Constants.IT205615_60X + Constants.CubicleWidth, Constants.IT204550_60Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205652 = new Vertex(Int32.MaxValue, "2056.52", Constants.IT205615_60X + Constants.CubicleWidth * 2, Constants.IT204550_60Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205653 = new Vertex(Int32.MaxValue, "2056.53", Constants.IT205615_60X + Constants.CubicleWidth * 3, Constants.IT204550_60Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205654 = new Vertex(Int32.MaxValue, "2056.54", Constants.IT205615_60X + Constants.CubicleWidth * 4 + 35, Constants.IT204550_60Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205655 = new Vertex(Int32.MaxValue, "2056.55", Constants.IT205615_60X + Constants.CubicleWidth * 5 + 35, Constants.IT204550_60Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205656 = new Vertex(Int32.MaxValue, "2056.56", Constants.IT205615_60X + Constants.CubicleWidth * 6 + 35, Constants.IT204550_60Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205657 = new Vertex(Int32.MaxValue, "2056.57", Constants.IT205615_60X + Constants.CubicleWidth * 7 + 35, Constants.IT204550_60Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v205658 = new Vertex(Int32.MaxValue, "2056.58", Constants.IT205615_60X + Constants.CubicleWidth * 8 + 79, Constants.IT204550_60Y, Constants.TripletWidth, Constants.CubicleHeight);
            Vertex v205658adj = Vertex.makeAdjacent(ref v205658, "v205658adj", 2, "up", 35);
            this.nodes.Add(v205658adj);
            
            Vertex v205659 = new Vertex(Int32.MaxValue, "2056.59", Constants.IT205615_60X + Constants.CubicleWidth * 8 + 79 + Constants.TripletWidth, Constants.IT204550_60Y, Constants.TripletWidth, Constants.CubicleHeight);
            Vertex v205659adj = Vertex.makeAdjacent(ref v205659, "v205659adj", 2, "up", 35);
            this.nodes.Add(v205659adj);
            Vertex v20566 = new Vertex(Int32.MaxValue, "2056.6", Constants.IT205615_60X + Constants.CubicleWidth * 8 + 79 + Constants.TripletWidth * 2, Constants.IT204550_60Y, Constants.TripletWidth, Constants.CubicleHeight);
            Vertex v20566adj = Vertex.makeAdjacent(ref v20566, "v20566adj", 2, "up", 35);
            this.nodes.Add(v20566adj);
            

            /***********************************/
            /***********************************/
            /** Connect vertices ***************/
            /***********************************/
            /***********************************/
            #region Connect vertices IT cubes
            Vertex.connectVertex(ref v205653, ref v205641adj, 1);
            Vertex.connectVertex(ref v20564adj, ref v205641adj, 1);
            Vertex.connectVertex(ref v205629walk, ref v205629adj, 1);
            Vertex.connectVertex(ref v205641walk, ref v205629walk, 2);
            Vertex.connectVertex(ref v205628adj, ref v205629adj, 1);
            Vertex.connectVertex(ref v20564adj, ref v205652, 1);
            Vertex.connectVertex(ref v205629adj, ref v205617, 1);
            Vertex.connectVertex(ref v205628adj, ref v205616, 1);
            Vertex.connectVertex(ref v205639adj, ref v205651, 1);
            Vertex.connectVertex(ref v205639adj, ref v20564adj, 1);
            Vertex.connectVertex(ref v205638adj, ref v205639adj, 1);
            Vertex.connectVertex(ref v205638adj, ref v20565, 1);
            Vertex.connectVertex(ref v205627adj, ref v205628adj, 1);
            Vertex.connectVertex(ref v205627adj, ref v205626adj, 1);
            Vertex.connectVertex(ref v205615, ref v205626adj, 1);
            Vertex.connectVertex(ref v205641walk, ref v205642adj, 1);
            Vertex.connectVertex(ref v205642adj, ref v205654, 1);
            Vertex.connectVertex(ref v205643adj, ref v205642adj, 1);
            Vertex.connectVertex(ref v205643adj, ref v205655, 1);
            Vertex.connectVertex(ref v205644adj, ref v205656, 1);
            Vertex.connectVertex(ref v205644adj, ref v205643adj, 1);
            Vertex.connectVertex(ref v205645adj, ref v205657, 1);
            Vertex.connectVertex(ref v205645adj, ref v205644adj, 1);
            Vertex.connectVertex(ref v205629walk, ref v20563adj, 1);
            Vertex.connectVertex(ref v205618, ref v20563adj, 1);
            Vertex.connectVertex(ref v205619, ref v205631adj, 1);
            Vertex.connectVertex(ref v20563adj, ref v205631adj, 1);
            Vertex.connectVertex(ref v20562, ref v205632adj, 1);
            Vertex.connectVertex(ref v205631adj, ref v205632adj, 1);
            Vertex.connectVertex(ref v205621, ref v205633adj, 1);
            Vertex.connectVertex(ref v205632adj, ref v205633adj, 1);
            Vertex.connectVertex(ref v205633walk, ref v205645walk, 2);
            Vertex.connectVertex(ref v205646adj, ref v205645walk, 1);
            
            Vertex.connectVertex(ref v205647adj, ref v205646adj, 1);
            Vertex.connectVertex(ref v205647adj, ref v205648adj, 1);
            Vertex.connectVertex(ref v205649adj, ref v205648adj, 1);
            Vertex.connectVertex(ref v205634adj, ref v205633walk, 1);
            Vertex.connectVertex(ref v205634adj, ref v205622, 1);
            Vertex.connectVertex(ref v205635adj, ref v205623, 1);
            Vertex.connectVertex(ref v205635adj, ref v205634adj, 1);
            Vertex.connectVertex(ref v205636adj, ref v205624, 1);
            Vertex.connectVertex(ref v205636adj, ref v205635adj, 1);
            Vertex.connectVertex(ref v205637adj, ref v205624, 1);
            Vertex.connectVertex(ref v205637adj, ref v205636adj, 1);
            Vertex.connectVertex(ref v205637walk, ref v205649walk, 2);
            Vertex.connectVertex(ref v205638walk, ref v205626walk, 2);
            Vertex.connectVertex(ref v205646adj, ref v205658adj, 1);
            Vertex.connectVertex(ref v205647adj, ref v205658adj, 1);
            Vertex.connectVertex(ref v205647adj, ref v205659adj, 1);
            Vertex.connectVertex(ref v205648adj, ref v205659adj, 1);
            Vertex.connectVertex(ref v205648adj, ref v20566adj, 1);
            Vertex.connectVertex(ref v205649adj, ref v205659adj, 1);

            Vertex.connectVertex(ref v205615adj, ref v205626adj, 1);
            Vertex.connectVertex(ref v205615adj, ref v205627adj, 1);
            Vertex.connectVertex(ref v205616adj, ref v205627adj, 1);
            Vertex.connectVertex(ref v205616adj, ref v205628adj, 1);
            Vertex.connectVertex(ref v205617adj, ref v205628adj, 1);
            Vertex.connectVertex(ref v205617adj, ref v205629adj, 1);
            #endregion





            //Directors
            Vertex v2057 = new Vertex(Int32.MaxValue, "2057", Constants.ITDirectorX + Constants.ITDirectorOfficeW * 9, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2058 = new Vertex(Int32.MaxValue, "2058", Constants.ITDirectorX + Constants.ITDirectorOfficeW * 8, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2059 = new Vertex(Int32.MaxValue, "2059", Constants.ITDirectorX + Constants.ITDirectorOfficeW * 7, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2060 = new Vertex(Int32.MaxValue, "2060", Constants.ITDirectorX + Constants.ITDirectorOfficeW * 6, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2061 = new Vertex(Int32.MaxValue, "2061", Constants.ITDirectorX + Constants.ITDirectorOfficeW * 5, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2062 = new Vertex(Int32.MaxValue, "2062", Constants.ITDirectorX + Constants.ITDirectorOfficeW * 4, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2063 = new Vertex(Int32.MaxValue, "2063", Constants.ITDirectorX + Constants.ITDirectorOfficeW * 3, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2064 = new Vertex(Int32.MaxValue, "2064", Constants.ITDirectorX + Constants.ITDirectorOfficeW * 2, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2065 = new Vertex(Int32.MaxValue, "2065", Constants.ITDirectorX + Constants.ITDirectorOfficeW, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2066 = new Vertex(Int32.MaxValue, "2066", Constants.ITDirectorX, Constants.ITDirectorY, Constants.ITDirectorOfficeW, Constants.ITDirectorOfficeH);
            Vertex v2068 = new Vertex(Int32.MaxValue, "2068", Constants.HROfficeX + Constants.HROfficeWidth, 730, 132, 70);

            Vertex v2057adj = Vertex.makeAdjacent(ref v2057, "v2057adj", 2, "up", 66);
            this.nodes.Add(v2057adj);
            Vertex v2057walk = Vertex.makeAdjacent(ref v2057adj, "v2057walk", 2, "right", 8);
            this.nodes.Add(v2057walk);
            Vertex v2058adj = Vertex.makeAdjacent(ref v2058, "v2058adj", 2, "up", 66);
            this.nodes.Add(v2058adj);
            Vertex v2059adj = Vertex.makeAdjacent(ref v2059, "v2059adj", 2, "up", 66);
            this.nodes.Add(v2059adj);
            Vertex v2060adj = Vertex.makeAdjacent(ref v2060, "v2060adj", 2, "up", 66);
            this.nodes.Add(v2060adj);
            Vertex v2060walk = Vertex.makeAdjacent(ref v2060adj, "v2060walk", 2, "right", 15);
            this.nodes.Add(v2060walk);
            Vertex v2061adj = Vertex.makeAdjacent(ref v2061, "v2061adj", 2, "up", 66);
            this.nodes.Add(v2061adj);
            Vertex v2062adj = Vertex.makeAdjacent(ref v2062, "v2062adj", 2, "up", 66);
            this.nodes.Add(v2062adj);
            Vertex v2063adj = Vertex.makeAdjacent(ref v2063, "v2063adj", 2, "up", 66);
            this.nodes.Add(v2063adj);
            Vertex v2063walk = Vertex.makeAdjacent(ref v2063adj, "v2063walk", 2, "right", 23);
            this.nodes.Add(v2063walk);
            Vertex v2064adj = Vertex.makeAdjacent(ref v2064, "v2064adj", 2, "up", 66);
            this.nodes.Add(v2064adj);
            Vertex v2065adj = Vertex.makeAdjacent(ref v2065, "v2065adj", 2, "up", 66);
            this.nodes.Add(v2065adj);
            Vertex v2066adj = Vertex.makeAdjacent(ref v2066, "v2066adj", 2, "up", 66);
            this.nodes.Add(v2066adj);
            Vertex v2066walk = Vertex.makeAdjacent(ref v2066adj, "v2066walk", 2, "right", 31);
            this.nodes.Add(v2066walk);
            Vertex v2068adj = Vertex.makeAdjacent(ref v2068, "v2068adj", 2, "right", 75);
            this.nodes.Add(v2068adj);
            Vertex v2068walk = Vertex.makeAdjacent(ref v2068adj, "v2068walk", 2, "right", 35);
            this.nodes.Add(v2068walk);


            #region Connect vertices IT Directors
            Vertex.connectVertex(ref v205613walk, ref v2066adj, 1);
            Vertex.connectVertex(ref v2057adj, ref v2057walk, 1);
            Vertex.connectVertex(ref v2057adj, ref v2058adj, 1);
            Vertex.connectVertex(ref v2059adj, ref v2058adj, 1);
            Vertex.connectVertex(ref v2059adj, ref v2060walk, 1);
            Vertex.connectVertex(ref v2060walk, ref v205645walk, 1);
            Vertex.connectVertex(ref v2060adj, ref v2061adj, 1);
            Vertex.connectVertex(ref v2062adj, ref v2061adj, 1);
            Vertex.connectVertex(ref v2063walk, ref v2062adj, 1);
            Vertex.connectVertex(ref v2063walk, ref v205641walk, 1);
            Vertex.connectVertex(ref v2063adj, ref v2064adj, 1);
            Vertex.connectVertex(ref v2065adj, ref v2064adj, 1);
            Vertex.connectVertex(ref v2065adj, ref v2066walk, 1);
            Vertex.connectVertex(ref v2066walk, ref v205638walk, 1);
            Vertex.connectVertex(ref v2068adj, ref v1060Sadj, 100);
            Vertex.connectVertex(ref v2057walk, ref v2054adj, 1);


            #endregion



            Vertex v2070 = new Vertex(Int32.MaxValue, "2070", Constants.FinanceDirectorX, Constants.FinanceDirectorY + Constants.FinanceDirectorHeight * 3, Constants.FinanceDirectorWidth, Constants.FinanceDirectorHeight + 2);
            Vertex v2070adj = Vertex.makeAdjacent(ref v2070, "v2070adj", 2, "right", 50);
            this.nodes.Add(v2070adj);
            Vertex v2070walk = Vertex.makeAdjacent(ref v2070adj, "v2070walk", 2, "down", 80);
            this.nodes.Add(v2070walk);

            Vertex v2071 = new Vertex(Int32.MaxValue, "2071", Constants.FinanceDirectorX, Constants.FinanceDirectorY + Constants.FinanceDirectorHeight * 2, Constants.FinanceDirectorWidth, Constants.FinanceDirectorHeight);
            Vertex v2071adj = Vertex.makeAdjacent(ref v2071, "v2071adj", 2, "right", 50);
            this.nodes.Add(v2071adj);
            Vertex v2071walk = Vertex.makeAdjacent(ref v2071adj, "v2071walk", 2, "up", 168);
            this.nodes.Add(v2071walk);
            
            



            Vertex v2072 = new Vertex(Int32.MaxValue, "2072", Constants.FinanceDirectorX, Constants.FinanceDirectorY + Constants.FinanceDirectorHeight, Constants.FinanceDirectorWidth, Constants.FinanceDirectorHeight);
            Vertex v2072adj = Vertex.makeAdjacent(ref v2072, "v2072adj", 2, "left", 50);
            this.nodes.Add(v2072adj);
            
            Vertex v2073 = new Vertex(Int32.MaxValue, "2073", Constants.FinanceDirectorX, Constants.FinanceDirectorY, Constants.FinanceDirectorWidth, Constants.FinanceDirectorHeight);
            Vertex v2073adj = Vertex.makeAdjacent(ref v2073, "v2073adj", 2, "left", 50);
            this.nodes.Add(v2073adj);
            Vertex v2073walk = Vertex.makeAdjacent(ref v2073adj, "v2073walk", 2, "up", 44);
            this.nodes.Add(v2073walk);

            
            //HR
            Vertex v207501 = new Vertex(Int32.MaxValue, "2075.01", Constants.HRCubicleX, Constants.HRCubicleY, Constants.HRCubicleWidth, Constants.HRCubicleHeight);
            Vertex v207501adj = Vertex.makeAdjacent(ref v207501, "v207501adj", 2, "left", 30);
            this.nodes.Add(v207501adj);
            Vertex v207501walk = Vertex.makeAdjacent(ref v207501adj, "v207501walk", 2, "up", 38);
            this.nodes.Add(v207501walk);

            Vertex v207502 = new Vertex(Int32.MaxValue, "2075.02", Constants.HRCubicleX, Constants.HRCubicleY + Constants.HRCubicleHeight, Constants.HRCubicleWidth, Constants.HRCubicleHeight);
            Vertex v207502adj = Vertex.makeAdjacent(ref v207502, "v207502adj", 2, "left", 30);
            this.nodes.Add(v207502adj);
            
            Vertex v207503 = new Vertex(Int32.MaxValue, "2075.03", Constants.HRCubicleX + 35, Constants.HRCubicleY + Constants.HRCubicleHeight*2, Constants.HRCubicleWidth, Constants.HRCubicleHeight);
            Vertex v207503adj = Vertex.makeAdjacent(ref v207503, "v207503adj", 2, "left", 65);
            this.nodes.Add(v207503adj);
            
            Vertex v207504 = new Vertex(Int32.MaxValue, "2075.04", Constants.HRCubicleX + 35, Constants.HRCubicleY + Constants.HRCubicleHeight*3, Constants.HRCubicleWidth, Constants.HRCubicleHeight);
            Vertex v207504adj = Vertex.makeAdjacent(ref v207504, "v207504adj", 2, "left", 65);
            this.nodes.Add(v207504adj);
            
            Vertex v2077 = new Vertex(Int32.MaxValue, "2077", Constants.HROfficeX, Constants.HROfficeY, Constants.HROfficeWidth, Constants.HROfficeHeight);
            Vertex v2077adj = Vertex.makeAdjacent(ref v2077, "v2077adj", 2, "right", 43);
            this.nodes.Add(v2077adj);
            
            Vertex v2078 = new Vertex(Int32.MaxValue, "2078", Constants.HROfficeX, Constants.HROfficeY + Constants.HROfficeHeight, Constants.HROfficeWidth, Constants.HROfficeHeight);
            Vertex v2078adj = Vertex.makeAdjacent(ref v2078, "v2078adj", 2, "right", 43);
            this.nodes.Add(v2078adj);
            
            Vertex v2079 = new Vertex(Int32.MaxValue, "2079", Constants.HROfficeX, Constants.HROfficeY + Constants.HROfficeHeight * 2, Constants.HROfficeWidth, Constants.HROfficeHeight);
            Vertex v2079adj = Vertex.makeAdjacent(ref v2079, "v2079adj", 2, "right", 43);
            this.nodes.Add(v2079adj);
            
            Vertex v2080 = new Vertex(Int32.MaxValue, "2080", Constants.HROfficeX, Constants.HROfficeY + Constants.HROfficeHeight * 3, Constants.HROfficeWidth, 88);
            Vertex v2080adj = Vertex.makeAdjacent(ref v2080, "v2080adj", 2, "right", 43);
            this.nodes.Add(v2080adj);

            Vertex v208101 = new Vertex(Int32.MaxValue, "2081.01", Constants.IT208101_14X, Constants.IT208101_14Y, 21, Constants.FinanceDoublesHeight);
            Vertex v208101adj = Vertex.makeAdjacent(ref v208101, "v208101adj", 2, "right", 18);
            this.nodes.Add(v208101adj);
            
            Vertex v208102 = new Vertex(Int32.MaxValue, "2081.02", Constants.IT208101_14X + Constants.FinanceDoublesWidth, Constants.IT208101_14Y, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208103 = new Vertex(Int32.MaxValue, "2081.03", Constants.IT208101_14X + Constants.FinanceDoublesWidth*2 + 35, Constants.IT208101_14Y, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208103adj = Vertex.makeAdjacent(ref v208103, "v208103adj", 2, "left", 35);
            this.nodes.Add(v208103adj);
            
            Vertex v208104 = new Vertex(Int32.MaxValue, "2081.04", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 3 + 35, Constants.IT208101_14Y, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208104adj = Vertex.makeAdjacent(ref v208104, "v208104adj", 2, "right", 35);
            this.nodes.Add(v208104adj);
            Vertex v208105 = new Vertex(Int32.MaxValue, "2081.05", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 4 + 70, Constants.IT208101_14Y, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208106 = new Vertex(Int32.MaxValue, "2081.06", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 5 + 70, Constants.IT208101_14Y, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208106adj = Vertex.makeAdjacent(ref v208106, "v208106adj", 2, "right", 35);
            this.nodes.Add(v208106adj);
            
            Vertex v208107 = new Vertex(Int32.MaxValue, "2081.07", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 6 + 105, Constants.IT208101_14Y, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208108 = new Vertex(Int32.MaxValue, "2081.08", Constants.IT208101_14X, Constants.IT208101_14Y + Constants.FinanceDoublesHeight, 21, Constants.FinanceDoublesHeight);
            Vertex v208108adj = Vertex.makeAdjacent(ref v208108, "v208108adj", 2, "right", 18);
            this.nodes.Add(v208108adj);
            
            Vertex v208109 = new Vertex(Int32.MaxValue, "2081.09", Constants.IT208101_14X + Constants.FinanceDoublesWidth, Constants.IT208101_14Y + Constants.FinanceDoublesHeight, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v20811 = new Vertex(Int32.MaxValue, "2081.1", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 2 + 35, Constants.IT208101_14Y + Constants.FinanceDoublesHeight, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v20811adj = Vertex.makeAdjacent(ref v20811, "v20811adj", 2, "left", 35);
            this.nodes.Add(v20811adj);
            
            Vertex v208111 = new Vertex(Int32.MaxValue, "2081.11", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 3 + 35, Constants.IT208101_14Y + Constants.FinanceDoublesHeight, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208111adj = Vertex.makeAdjacent(ref v208111, "v208111adj", 2, "right", 35);
            this.nodes.Add(v208111adj);
            Vertex v208111walk = Vertex.makeAdjacent(ref v208111adj, "v208111walk", 2, "down", 41);
            this.nodes.Add(v208111walk);

            Vertex v208112 = new Vertex(Int32.MaxValue, "2081.12", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 4 + 70, Constants.IT208101_14Y + Constants.FinanceDoublesHeight, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208113 = new Vertex(Int32.MaxValue, "2081.13", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 5 + 70, Constants.IT208101_14Y + Constants.FinanceDoublesHeight, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);
            Vertex v208113adj = Vertex.makeAdjacent(ref v208113, "v208113adj", 2, "right", 35);
            this.nodes.Add(v208113adj);
            Vertex v208113walk = Vertex.makeAdjacent(ref v208113adj, "v208113walk", 2, "down", 41);
            this.nodes.Add(v208113walk);
            Vertex v208114 = new Vertex(Int32.MaxValue, "2081.14", Constants.IT208101_14X + Constants.FinanceDoublesWidth * 6 + 105, Constants.IT208101_14Y + Constants.FinanceDoublesHeight, Constants.FinanceDoublesWidth, Constants.FinanceDoublesHeight);


            Vertex v20811walk = Vertex.makeAdjacent(ref v2073walk, "v20811walk", 2, "left", 51);
            this.nodes.Add(v20811walk);
            Vertex v208108walk = Vertex.makeAdjacent(ref v208108adj, "v208108walk", 2, "down", 41);
            this.nodes.Add(v208108walk);

            #region Connect HR vertices
            Vertex.connectVertex(ref v2071adj, ref v2070adj, 1);
            Vertex.connectVertex(ref v2070walk, ref v205613walk, 1);
            Vertex.connectVertex(ref v2070walk, ref v2068walk, 1);

            Vertex.connectVertex(ref v208106adj, ref v208113adj, 1);
            Vertex.connectVertex(ref v208113walk, ref v205601adj, 1);
            Vertex.connectVertex(ref v208113walk, ref v2071walk, 1);
            Vertex.connectVertex(ref v208106adj, ref v208107, 1);
            Vertex.connectVertex(ref v208113adj, ref v208114, 1);
            Vertex.connectVertex(ref v208111adj, ref v208112, 1);
            Vertex.connectVertex(ref v208104adj, ref v208105, 1);
            Vertex.connectVertex(ref v208104adj, ref v208111adj, 1);
            Vertex.connectVertex(ref v208111walk, ref v2071walk, 1);
            Vertex.connectVertex(ref v2073adj, ref v2072adj, 1);
            Vertex.connectVertex(ref v208111walk, ref v2073walk, 1);
            Vertex.connectVertex(ref v208108adj, ref v208101adj, 1);

            Vertex.connectVertex(ref v208108walk, ref v207501walk, 1);
            Vertex.connectVertex(ref v207501walk, ref v20811walk, 1);
            Vertex.connectVertex(ref v2077adj, ref v207501adj, 1);
            Vertex.connectVertex(ref v2077adj, ref v207502adj, 1);
            Vertex.connectVertex(ref v2078adj, ref v207502adj, 1);
            Vertex.connectVertex(ref v2078adj, ref v207503adj, 1);
            Vertex.connectVertex(ref v2079adj, ref v207503adj, 1);
            Vertex.connectVertex(ref v2078adj, ref v207504adj, 1);
            Vertex.connectVertex(ref v2080adj, ref v207504adj, 1);
            Vertex.connectVertex(ref v20811adj, ref v20811walk, 1);
            Vertex.connectVertex(ref v20811adj, ref v208103adj, 1);
            Vertex.connectVertex(ref v208101adj, ref v208102, 1);
            Vertex.connectVertex(ref v208108adj, ref v208109, 1);
            #endregion



            Vertex v2082 = new Vertex(Int32.MaxValue, "2082", 0, 0);
            
            Vertex v2084 = new Vertex(Int32.MaxValue, "2084", 1, 97, 70 ,158);
            Vertex v2084adj = Vertex.makeAdjacent(ref v2084, "v2084adj", 2, "right", 52);
            this.nodes.Add(v2084adj);
            
            Vertex v2085 = new Vertex(Int32.MaxValue, "2085", 1, 1, 132, Constants.ExecutiveOfficeHeight);
            Vertex v2085adj = Vertex.makeAdjacent(ref v2085, "v2085adj", 2, "right", 21);
            this.nodes.Add(v2085adj);
            Vertex v2085walk = Vertex.makeAdjacent(ref v2085adj, "v2085walk", 2, "down", 68);
            this.nodes.Add(v2085walk);

            Vertex v2086 = new Vertex(Int32.MaxValue, "2086", 133, 1,88, Constants.ExecutiveOfficeHeight );
            Vertex v2086adj = Vertex.makeAdjacent(ref v2086, "v2086adj", 2, "down", 68);
            this.nodes.Add(v2086adj);
            
            Vertex v2087 = new Vertex(Int32.MaxValue, "2087", 133+88, 1, 88, Constants.ExecutiveOfficeHeight);
            Vertex v2087adj = Vertex.makeAdjacent(ref v2087, "v2087adj", 2, "down", 68);
            this.nodes.Add(v2087adj);
            
            Vertex v2088 = new Vertex(Int32.MaxValue, "2088", 133 + 88*2, 1, 88, Constants.ExecutiveOfficeHeight);
            Vertex v2088adj = Vertex.makeAdjacent(ref v2088, "v2088adj", 2, "down", 68);
            this.nodes.Add(v2088adj);
            
            Vertex v2089 = new Vertex(Int32.MaxValue, "2089", 133 + 88*3, 1, 88, Constants.ExecutiveOfficeHeight);
            Vertex v2089adj = Vertex.makeAdjacent(ref v2089, "v2089adj", 2, "down", 68);
            this.nodes.Add(v2089adj);
            
            
            Vertex v2090 = new Vertex(Int32.MaxValue, "2090", 133 + 88*4, 1, 106, Constants.ExecutiveOfficeHeight );
            Vertex v2090adj = Vertex.makeAdjacent(ref v2090, "v2090adj", 2, "down", 68);
            this.nodes.Add(v2090adj);
            

            Vertex v2091 = new Vertex(Int32.MaxValue, "2091", Constants.ExecutiveBreakRoomX, Constants.ExecutiveBreakRoomY, Constants.ExecutiveBreakRoomWidth, Constants.ExecutiveBreakRoomHeight);
            Vertex v2091adj = Vertex.makeAdjacent(ref v2091, "v2091adj", 2, "down", 62);
            this.nodes.Add(v2091adj);
            
            Vertex v2092 = new Vertex(Int32.MaxValue, "2092", Constants.ExecutiveBoardRoomX, Constants.ExecutiveBoardRoomY, Constants.ExecutiveBoardRoomWidth, Constants.ExecutiveBoardRoomHeight);
            Vertex v2092adj = Vertex.makeAdjacent(ref v2092, "v2092adj", 2, "down", 62);
            this.nodes.Add(v2092adj);
            Vertex v2092walk = Vertex.makeAdjacent(ref v2092adj, "v2092walk", 2, "left", 86);
            this.nodes.Add(v2092walk);

            Vertex v2094 = new Vertex(Int32.MaxValue, "2094", Constants.Executive2094_2096X, Constants.Executive2094_2096Y, 52, 70);
            Vertex v2094adj = Vertex.makeAdjacent(ref v2094, "v2094adj", 2, "up", 50);
            this.nodes.Add(v2094adj);

            Vertex v2095 = new Vertex(Int32.MaxValue, "2095", Constants.Executive2094_2096X + 52, Constants.Executive2094_2096Y, 95, 122);
            Vertex v2095adj = Vertex.makeAdjacent(ref v2095, "v2095adj", 2, "up", 76);
            this.nodes.Add(v2095adj);
            
            Vertex v2096 = new Vertex(Int32.MaxValue, "2096", Constants.Executive2094_2096X + 147, Constants.Executive2094_2096Y, 95, 122);
            Vertex v2096adj = Vertex.makeAdjacent(ref v2096, "v2096adj", 2, "up", 76);
            this.nodes.Add(v2096adj);

            Vertex v2099 = new Vertex(Int32.MaxValue, "2099", Constants.Room2099X, Constants.Room2099Y, Constants.Room2099Width, Constants.Room2099Height);
            Vertex v2099adj = Vertex.makeAdjacent(ref v2099, "v2099adj", 2, "left", 40);
            this.nodes.Add(v2099adj);
            Vertex v2099walk = Vertex.makeAdjacent(ref v2099, "v2099walk", 2, "up", 40);
            this.nodes.Add(v2099walk);
            Vertex v2099corner = Vertex.makeAdjacent(ref v2099walk, "v2099corner", 2, "left", 40);
            this.nodes.Add(v2099corner);
            Vertex.connectVertex(ref v2099corner, ref v2099adj, 1);
            Vertex v2088walk = Vertex.makeAdjacent(ref v2099corner, "v2088walk", 2, "up", 218);
            this.nodes.Add(v2088walk);
            

            #region Connect Wirtz Wing
            Vertex.connectVertex(ref v2088walk, ref v2088adj, 1);
            Vertex.connectVertex(ref v2099adj, ref v208113walk, 1);
            Vertex.connectVertex(ref v2099adj, ref v205626walk, 1);
            Vertex.connectVertex(ref v2084adj, ref v208103adj, 1);
            Vertex.connectVertex(ref v2085walk, ref v2084adj, 1);
            Vertex.connectVertex(ref v2085walk, ref v2094adj, 1);
            Vertex.connectVertex(ref v2094adj, ref v2086adj, 1);
            Vertex.connectVertex(ref v2086adj, ref v2095adj, 1);
            Vertex.connectVertex(ref v2087adj, ref v2095adj, 1);
            Vertex.connectVertex(ref v2087adj, ref v2096adj, 1);
            Vertex.connectVertex(ref v2088adj, ref v2096adj, 1);
            Vertex.connectVertex(ref v2089adj, ref v2088walk, 1);
            Vertex.connectVertex(ref v2091adj, ref v2092walk, 1);
            #endregion


            //West Finance
            Vertex v209701 = new Vertex(Int32.MaxValue, "2097.01", Constants.Finance209701_19X, Constants.Finance209701_19Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209701adj = Vertex.makeAdjacent(ref v209701, "v209701adj", 2, "right", 28);
            this.nodes.Add(v209701adj);
            
            Vertex v209702 = new Vertex(Int32.MaxValue, "2097.02", Constants.Finance209701_19X + Constants.CubicleWidth + 30, Constants.Finance209701_19Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209703 = new Vertex(Int32.MaxValue, "2097.03", Constants.Finance209701_19X + Constants.CubicleWidth *2 + 30, Constants.Finance209701_19Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209703adj = Vertex.makeAdjacent(ref v209703, "v209703adj", 2, "right", 25);
            this.nodes.Add(v209703adj);
            
            Vertex v209704 = new Vertex(Int32.MaxValue, "2097.04", Constants.Finance209701_19X + Constants.CubicleWidth * 3 + 60, Constants.Finance209701_19Y, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209705 = new Vertex(Int32.MaxValue, "2097.05", Constants.Finance209701_19X + Constants.CubicleWidth + 30,Constants.Finance209701_19Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209705adj = Vertex.makeAdjacent(ref v209705, "v209705adj", 2, "left", 37);
            this.nodes.Add(v209705adj);
            
            
            Vertex v209706 = new Vertex(Int32.MaxValue, "2097.06", Constants.Finance209701_19X + Constants.CubicleWidth*2 + 30, Constants.Finance209701_19Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209706adj = Vertex.makeAdjacent(ref v209706, "v209706adj", 2, "right", 25);
            this.nodes.Add(v209706adj);
            
            Vertex v209707 = new Vertex(Int32.MaxValue, "2097.07", Constants.Finance209701_19X + Constants.CubicleWidth*3 + 60, Constants.Finance209701_19Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209708 = new Vertex(Int32.MaxValue, "2097.08", Constants.Finance209701_19X + Constants.CubicleWidth*4 + 60, Constants.Finance209701_19Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209708adj = Vertex.makeAdjacent(ref v209708, "v209708adj", 2, "right", 33);
            this.nodes.Add(v209708adj);


            Vertex v209709 = new Vertex(Int32.MaxValue, "2097.09", Constants.Finance209701_19X + Constants.CubicleWidth*5 + 90, Constants.Finance209701_19Y + Constants.CubicleHeight, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v20971 = new Vertex(Int32.MaxValue, "2097.1", Constants.Finance209701_19X + Constants.CubicleWidth + 30, Constants.Finance209701_19Y + Constants.CubicleHeight*2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v20971adj = Vertex.makeAdjacent(ref v20971, "v20971adj", 2, "left", 37);
            this.nodes.Add(v20971adj);

            Vertex v209711 = new Vertex(Int32.MaxValue, "2097.11", Constants.Finance209701_19X + Constants.CubicleWidth * 2 + 30, Constants.Finance209701_19Y + Constants.CubicleHeight*2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209711adj = Vertex.makeAdjacent(ref v209711, "v209711adj", 2, "right", 25);
            this.nodes.Add(v209711adj);
            
            Vertex v209712 = new Vertex(Int32.MaxValue, "2097.12", Constants.Finance209701_19X + Constants.CubicleWidth * 3 + 60, Constants.Finance209701_19Y + Constants.CubicleHeight*2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209713 = new Vertex(Int32.MaxValue, "2097.13", Constants.Finance209701_19X + Constants.CubicleWidth * 4 + 60, Constants.Finance209701_19Y + Constants.CubicleHeight*2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209713adj = Vertex.makeAdjacent(ref v209713, "v209713adj", 2, "right", 33);
            this.nodes.Add(v209713adj);
            
            Vertex v209714 = new Vertex(Int32.MaxValue, "2097.14", Constants.Finance209701_19X + Constants.CubicleWidth * 5 + 90, Constants.Finance209701_19Y + Constants.CubicleHeight*2, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209715 = new Vertex(Int32.MaxValue, "2097.15", Constants.Finance209701_19X + Constants.CubicleWidth + 30, Constants.Finance209701_19Y + Constants.CubicleHeight * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209715adj = Vertex.makeAdjacent(ref v209715, "v209715adj", 2, "left", 37);
            this.nodes.Add(v209715adj);
            
            Vertex v209716 = new Vertex(Int32.MaxValue, "2097.16", Constants.Finance209701_19X + Constants.CubicleWidth * 2 + 30, Constants.Finance209701_19Y + Constants.CubicleHeight * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209716adj = Vertex.makeAdjacent(ref v209716, "v209716adj", 2, "right", 25);
            this.nodes.Add(v209716adj);
            
            Vertex v209717 = new Vertex(Int32.MaxValue, "2097.17", Constants.Finance209701_19X + Constants.CubicleWidth * 3 + 60, Constants.Finance209701_19Y + Constants.CubicleHeight * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209718 = new Vertex(Int32.MaxValue, "2097.18", Constants.Finance209701_19X + Constants.CubicleWidth * 4 + 60, Constants.Finance209701_19Y + Constants.CubicleHeight * 3, Constants.CubicleWidth, Constants.CubicleHeight);
            Vertex v209718adj = Vertex.makeAdjacent(ref v209718, "v209718adj", 2, "right", 33);
            this.nodes.Add(v209718adj);
            
            Vertex v209719 = new Vertex(Int32.MaxValue, "2097.19", Constants.Finance209701_19X + Constants.CubicleWidth * 5 + 90, Constants.Finance209701_19Y + Constants.CubicleHeight * 3, Constants.CubicleWidth, Constants.CubicleHeight);

            #region Connect finance 

            Vertex.connectVertex(ref v2089adj, ref v209701adj, 1);
            Vertex.connectVertex(ref v2089adj, ref v2090adj, 1);
            Vertex.connectVertex(ref v209701adj, ref v209702, 1);
            Vertex.connectVertex(ref v209701adj, ref v209705adj, 1);
            Vertex.connectVertex(ref v20971adj, ref v209705adj, 1);
            Vertex.connectVertex(ref v20971adj, ref v209715adj, 1);
            Vertex.connectVertex(ref v209703adj, ref v2090adj, 1);
            Vertex.connectVertex(ref v209703adj, ref v209706adj, 1);
            Vertex.connectVertex(ref v209711adj, ref v209706adj, 1);
            Vertex.connectVertex(ref v209711adj, ref v209716adj, 1);
            Vertex.connectVertex(ref v209703adj, ref v209704, 1);
            Vertex.connectVertex(ref v209711adj, ref v209712, 1);
            Vertex.connectVertex(ref v209707, ref v209706adj, 1);
            Vertex.connectVertex(ref v209716adj, ref v209717, 1);
            Vertex.connectVertex(ref v2091adj, ref v2090adj, 1);
            Vertex.connectVertex(ref v209708adj, ref v209709, 1);
            Vertex.connectVertex(ref v209713adj, ref v209714, 1);
            Vertex.connectVertex(ref v209718adj, ref v209719, 1);
            Vertex.connectVertex(ref v209718adj, ref v209713adj, 1);
            Vertex.connectVertex(ref v209708adj, ref v209713adj, 1);
            Vertex.connectVertex(ref v209708adj, ref v2091adj, 1);
            #endregion




            Vertex v2100 = new Vertex(Int32.MaxValue, "2100", Constants.Room2100X, Constants.Room2100Y, Constants.Room2100Width, Constants.Room2100Height);
            Vertex v2100adj = Vertex.makeAdjacent(ref v2100, "v2100adj", 2, "up", 40);
            this.nodes.Add(v2100adj);
            Vertex v2100walk = Vertex.makeAdjacent(ref v2100adj, "v2100walk", 2, "left", 21);
            this.nodes.Add(v2100walk);
            Vertex.connectVertex(ref v2100walk, ref v2099walk, 1);
            Vertex.connectVertex(ref v2100walk, ref v209715adj, 1);

            Vertex v2101 = new Vertex(Int32.MaxValue, "2101", Constants.SecondFloorSWomenBRX, Constants.SecondFloorSWomenBRY, Constants.SecondFloorSWomenBRWidth, Constants.SecondFloorSWomenBRHeight);
            Vertex v2101adj = Vertex.makeAdjacent(ref v2101, "v2101adj", 2, "right", 129);
            this.nodes.Add(v2101adj);
            Vertex v2102 = new Vertex(Int32.MaxValue, "2102", Constants.SecondFloorSMenBRX, Constants.SecondFloorSMenBRY, Constants.SecondFloorSMenBRWidth, Constants.SecondFloorSMenBRHeight);
            Vertex v2102adj = Vertex.makeAdjacent(ref v2102, "v2102adj", 2, "right", 129);
            this.nodes.Add(v2102adj);

            Vertex v2105 = new Vertex(Int32.MaxValue, "2105", 746, 274, 80, 80);
            Vertex v2106 = new Vertex(Int32.MaxValue, "2106", 826, 388, 100, 67);
            Vertex v2106adj = Vertex.makeAdjacent(ref v2106, "v2106adj", 2, "right", 26);
            this.nodes.Add(v2106adj);
            Vertex.connectVertex(ref v2106adj, ref v205637walk, 1);

            Vertex v2107 = new Vertex(Int32.MaxValue, "2107", 826, 274, 100, 114);
            Vertex v2107adj = Vertex.makeAdjacent(ref v2107, "v2107adj", 2, "down", 44);
            this.nodes.Add(v2107adj);

            Vertex v2108 = new Vertex(Int32.MaxValue, "2108", 746, 388, 80, 67);
            Vertex v2108adj = Vertex.makeAdjacent(ref v2108, "v2108adj", 2, "up", 46);
            this.nodes.Add(v2108adj);

            Vertex v2109 = new Vertex(Int32.MaxValue, "2109", 0, 0);

            #region Connect Second Floor S side, extra rooms
            Vertex.connectVertex(ref v2101adj, ref v2102adj, 1);
            Vertex.connectVertex(ref v2102adj, ref v205633walk, 1);
            Vertex.connectVertex(ref v2101adj, ref v2108adj, 1);
            Vertex.connectVertex(ref v2105, ref v2108adj, 1);
            Vertex.connectVertex(ref v2107adj, ref v2108adj, 1);

            Vertex.connectVertex(ref v2101adj, ref vSecondFloorConnectNS, 2);
            Vertex.connectVertex(ref vSecondFloorConnectNS, ref v2092walk, 2);
            #endregion

            #endregion

            #region Add First Floor

            this.nodes.Add(v1001);
            this.nodes.Add(v1002);
            this.nodes.Add(v1003);
            this.nodes.Add(v1004);
            this.nodes.Add(v1005);
            this.nodes.Add(v1006);
            this.nodes.Add(v100601);
            this.nodes.Add(v100602);
            this.nodes.Add(v100603);
            this.nodes.Add(v100604);
            this.nodes.Add(v100605);
            this.nodes.Add(v100606);
            this.nodes.Add(v100607);
            this.nodes.Add(v100608);
            this.nodes.Add(v100609);
            this.nodes.Add(v1007);
            this.nodes.Add(v1009);
            this.nodes.Add(v100901);
            this.nodes.Add(v100902);
            this.nodes.Add(v100903);
            this.nodes.Add(v100904);
            this.nodes.Add(v101001);
            this.nodes.Add(v101002);
            this.nodes.Add(v101003);
            this.nodes.Add(v101004);
            this.nodes.Add(v101005);
            this.nodes.Add(v101006);
            this.nodes.Add(v101007);
            this.nodes.Add(v101008);
            this.nodes.Add(v101009);
            this.nodes.Add(v10101);
            this.nodes.Add(v101011);
            this.nodes.Add(v101101);
            this.nodes.Add(v101102);
            this.nodes.Add(v101103);
            this.nodes.Add(v101104);
            this.nodes.Add(v101105);
            this.nodes.Add(v101106);
            this.nodes.Add(v1012);
            this.nodes.Add(v101301);
            this.nodes.Add(v101302);
            this.nodes.Add(v1015);
            this.nodes.Add(v1017);
            this.nodes.Add(v1020);
            this.nodes.Add(v1023);
            this.nodes.Add(v1025);
            this.nodes.Add(v1026);
            this.nodes.Add(v1027);
            this.nodes.Add(v1028);
            this.nodes.Add(v1029);
            this.nodes.Add(v1030);
            this.nodes.Add(v103101);
            this.nodes.Add(v103102);
            this.nodes.Add(v1032);
            this.nodes.Add(v1033);
            this.nodes.Add(v1037);
            this.nodes.Add(v1038);
            this.nodes.Add(v1039);
            this.nodes.Add(v1040);
            this.nodes.Add(v1041);
            this.nodes.Add(v1043);
            this.nodes.Add(v104501);
            this.nodes.Add(v104502);
            this.nodes.Add(v104503);
            this.nodes.Add(v104504);
            this.nodes.Add(v1046);
            this.nodes.Add(v1047);
            this.nodes.Add(v1048);
            this.nodes.Add(v104801);
            this.nodes.Add(v104802);
            this.nodes.Add(v104803);
            this.nodes.Add(v104804);
            this.nodes.Add(v104805);
            this.nodes.Add(v104806);
            this.nodes.Add(v1049);
            this.nodes.Add(v1050);
            this.nodes.Add(v1052);
            this.nodes.Add(v1053);
            this.nodes.Add(v1055);
            this.nodes.Add(v1059);
            this.nodes.Add(v1060);
            this.nodes.Add(v1060S);
            this.nodes.Add(v1061);
            this.nodes.Add(v1063);
            this.nodes.Add(v1064);
            this.nodes.Add(v1065);
            this.nodes.Add(v1066);
            this.nodes.Add(v1067);
            this.nodes.Add(v1068);
            this.nodes.Add(v1069);
            this.nodes.Add(v1070);
            this.nodes.Add(v1071);
            this.nodes.Add(v1072);
            this.nodes.Add(v1073);
            this.nodes.Add(v1074);
            this.nodes.Add(v1075);
            this.nodes.Add(v1076);
            this.nodes.Add(v1077);
            this.nodes.Add(v107701);
            this.nodes.Add(v107702);
            this.nodes.Add(v107703);
            this.nodes.Add(v107704);
            this.nodes.Add(v107705);
            this.nodes.Add(v107706);
            this.nodes.Add(v107707);
            this.nodes.Add(v107708);
            this.nodes.Add(v107709);
            this.nodes.Add(v10771);
            this.nodes.Add(v107711);
            this.nodes.Add(v107712);
            this.nodes.Add(v107713);
            this.nodes.Add(v107714);
            this.nodes.Add(v107715);
            this.nodes.Add(v10771601);
            this.nodes.Add(v10771602);
            this.nodes.Add(v1078);
            this.nodes.Add(v1079);
            this.nodes.Add(v1080);
            this.nodes.Add(v108101);
            this.nodes.Add(v108102);
            this.nodes.Add(v108103);
            this.nodes.Add(v108104);
            this.nodes.Add(v108105);
            this.nodes.Add(v108106);
            this.nodes.Add(v108107);
            this.nodes.Add(v108108);
            this.nodes.Add(v108109);
            this.nodes.Add(v10811);
            this.nodes.Add(v108111);
            this.nodes.Add(v108112);
            this.nodes.Add(v108113);
            this.nodes.Add(v108114);
            this.nodes.Add(v108115);
            this.nodes.Add(v108116);
            this.nodes.Add(v108117);
            this.nodes.Add(v108118);
            this.nodes.Add(v108119);
            this.nodes.Add(v10812);
            this.nodes.Add(v108121);
            this.nodes.Add(v108122);
            this.nodes.Add(v108123);
            this.nodes.Add(v108124);
            this.nodes.Add(v108125);
            this.nodes.Add(v108126);
            this.nodes.Add(v108127);
            this.nodes.Add(v108128);
            this.nodes.Add(v108129);
            this.nodes.Add(v10813);
            this.nodes.Add(v108131);
            this.nodes.Add(v108132);
            this.nodes.Add(v108133);
            this.nodes.Add(v108134);
            this.nodes.Add(v108135);
            this.nodes.Add(v108136);
            this.nodes.Add(v108137);
            this.nodes.Add(v108138);
            this.nodes.Add(v108139);
            this.nodes.Add(v10814);
            this.nodes.Add(v108141);
            this.nodes.Add(v108142);
            this.nodes.Add(v108143);
            this.nodes.Add(v108144);
            this.nodes.Add(v108145);
            this.nodes.Add(v108146);
            this.nodes.Add(v108147);
            this.nodes.Add(v108148);
            this.nodes.Add(v108149);
            this.nodes.Add(v10815);
            this.nodes.Add(v108151);
            this.nodes.Add(v108152);
            this.nodes.Add(v108153);
            this.nodes.Add(v108154);
            this.nodes.Add(v108155);
            this.nodes.Add(v108156);
            this.nodes.Add(v1082);
            this.nodes.Add(v1083);
            this.nodes.Add(v1086);
            this.nodes.Add(v1087);
            this.nodes.Add(v1088);
            this.nodes.Add(v1089);
            this.nodes.Add(v1090);
            this.nodes.Add(v1091);
            this.nodes.Add(v1092);
            this.nodes.Add(v1095);
            this.nodes.Add(v1096);
            this.nodes.Add(v1097);
            this.nodes.Add(v1098);
            this.nodes.Add(v1100);
            this.nodes.Add(v1101);
            this.nodes.Add(v110201);
            this.nodes.Add(v110202);
            this.nodes.Add(v110203);
            this.nodes.Add(v110204);
            this.nodes.Add(v1103);
            this.nodes.Add(v1104);
            this.nodes.Add(v1105);
            this.nodes.Add(v110601);
            this.nodes.Add(v110602);
            this.nodes.Add(v110603);
            this.nodes.Add(v110604);
            this.nodes.Add(v110701);
            this.nodes.Add(v110702);
            this.nodes.Add(v110703);
            this.nodes.Add(v110801);
            this.nodes.Add(v110802);
            this.nodes.Add(v1109);
            this.nodes.Add(v111001);
            this.nodes.Add(v111002);
            this.nodes.Add(v111101);
            this.nodes.Add(v111102);
            this.nodes.Add(v111103);
            this.nodes.Add(v111104);
            this.nodes.Add(v111105);
            this.nodes.Add(v111106);
            this.nodes.Add(v1112);
            this.nodes.Add(v1113);
            this.nodes.Add(v111801);
            this.nodes.Add(v111802);
            this.nodes.Add(v111803);
            this.nodes.Add(v111804);
            this.nodes.Add(v111805);
            this.nodes.Add(v1119);
            this.nodes.Add(v1120);
            this.nodes.Add(v112001);
            this.nodes.Add(v112101);
            this.nodes.Add(v112102);
            this.nodes.Add(v112103);
            this.nodes.Add(v112104);
            this.nodes.Add(v112105);
            this.nodes.Add(v112106);
            this.nodes.Add(v112107);
            this.nodes.Add(v1123);
            this.nodes.Add(v1126);
            this.nodes.Add(v1127);
            this.nodes.Add(v1128);
            this.nodes.Add(v1129);
            this.nodes.Add(v1130);
            this.nodes.Add(v1131);
            this.nodes.Add(v1132);
            this.nodes.Add(v1133);
            this.nodes.Add(v113301);
            
            #endregion

            #region Add Second Floor

            this.nodes.Add(v2007);
            this.nodes.Add(v200701);
            this.nodes.Add(v200702);
            this.nodes.Add(v200703);
            this.nodes.Add(v200704);
            this.nodes.Add(v200705);
            this.nodes.Add(v200706);
            this.nodes.Add(v200707);
            this.nodes.Add(v200708);
            this.nodes.Add(v200709);
            this.nodes.Add(v20071);
            this.nodes.Add(v200711);
            this.nodes.Add(v200712);
            this.nodes.Add(v200713);
            this.nodes.Add(v200900);
            this.nodes.Add(v201000);
            this.nodes.Add(v2011);
            this.nodes.Add(v2012);
            this.nodes.Add(v2013);
            this.nodes.Add(v2014);
            this.nodes.Add(v2015);
            this.nodes.Add(v2016);
            this.nodes.Add(v2017);
            this.nodes.Add(v2018);
            this.nodes.Add(v201901);
            this.nodes.Add(v201902);
            this.nodes.Add(v201903);
            this.nodes.Add(v201904);
            this.nodes.Add(v201905);
            this.nodes.Add(v201906);
            this.nodes.Add(v201907);
            this.nodes.Add(v201908);
            this.nodes.Add(v201909);
            this.nodes.Add(v20191);
            this.nodes.Add(v201911);
            this.nodes.Add(v201912);
            this.nodes.Add(v201913);
            this.nodes.Add(v201914);
            this.nodes.Add(v201915);
            this.nodes.Add(v201916);
            this.nodes.Add(v2020);
            this.nodes.Add(v2021);
            this.nodes.Add(v2022);
            this.nodes.Add(v2023);
            this.nodes.Add(v2024);
            this.nodes.Add(v2025);
            this.nodes.Add(v202601);
            this.nodes.Add(v202602);
            this.nodes.Add(v202603);
            this.nodes.Add(v202604);
            this.nodes.Add(v202605);
            this.nodes.Add(v202606);
            this.nodes.Add(v202607);
            this.nodes.Add(v202608);
            this.nodes.Add(v202609);
            this.nodes.Add(v20261);
            this.nodes.Add(v202611);
            this.nodes.Add(v202612);
            this.nodes.Add(v202613);
            this.nodes.Add(v202614);
            this.nodes.Add(v202615);
            this.nodes.Add(v202616);
            this.nodes.Add(v202617);
            this.nodes.Add(v202701);
            this.nodes.Add(v202702);
            this.nodes.Add(v202703);
            this.nodes.Add(v202704);
            this.nodes.Add(v202705);
            this.nodes.Add(v202706);
            this.nodes.Add(v202707);
            this.nodes.Add(v202708);
            this.nodes.Add(v202709);
            this.nodes.Add(v202710);
            this.nodes.Add(v202711);
            this.nodes.Add(v202712);
            this.nodes.Add(v202713);
            this.nodes.Add(v202714);
            this.nodes.Add(v202715);
            this.nodes.Add(v202716);
            this.nodes.Add(v202717);
            this.nodes.Add(v202718);
            this.nodes.Add(v202719);
            this.nodes.Add(v202720);
            this.nodes.Add(v202721);
            this.nodes.Add(v202722);
            this.nodes.Add(v202723);
            this.nodes.Add(v202724);
            this.nodes.Add(v202725);
            this.nodes.Add(v202726);
            this.nodes.Add(v202727);
            this.nodes.Add(v202728);
            this.nodes.Add(v202729);
            this.nodes.Add(v202730);
            this.nodes.Add(v202731);
            this.nodes.Add(v202732);
            this.nodes.Add(v202733);
            this.nodes.Add(v202734);
            this.nodes.Add(v202735);
            this.nodes.Add(v202736);
            this.nodes.Add(v202737);
            this.nodes.Add(v202738);
            this.nodes.Add(v202739);
            this.nodes.Add(v202740);
            this.nodes.Add(v202741);
            this.nodes.Add(v202742);
            this.nodes.Add(v202743);
            this.nodes.Add(v202744);
            this.nodes.Add(v202745);
            this.nodes.Add(v202746);
            this.nodes.Add(v202747);
            this.nodes.Add(v202748);
            this.nodes.Add(v202749);
            this.nodes.Add(v202750);
            this.nodes.Add(v202751);
            this.nodes.Add(v202752);
            this.nodes.Add(v202753);
            this.nodes.Add(v202754);
            this.nodes.Add(v2028);
            this.nodes.Add(v2029);
            this.nodes.Add(v2030);
            this.nodes.Add(v2031);
            this.nodes.Add(v2032);
            this.nodes.Add(v2033);
            this.nodes.Add(v2034);
            this.nodes.Add(v2035);
            this.nodes.Add(v2036);
            this.nodes.Add(v2037);
            this.nodes.Add(v2038);
            this.nodes.Add(v2039);
            this.nodes.Add(v2040);
            this.nodes.Add(v2041);
            this.nodes.Add(v2042);
            this.nodes.Add(v2043);
            this.nodes.Add(v2044);
            this.nodes.Add(v2045);
            this.nodes.Add(v2046);
            this.nodes.Add(v2047);
            this.nodes.Add(v2048);
            this.nodes.Add(v2049);
            this.nodes.Add(v2050);
            this.nodes.Add(v2051);
            this.nodes.Add(v2052);
            this.nodes.Add(v2053);
            this.nodes.Add(v2054);
            this.nodes.Add(v205601);
            this.nodes.Add(v205602);
            this.nodes.Add(v205603);
            this.nodes.Add(v205604);
            this.nodes.Add(v205605);
            this.nodes.Add(v205606);
            this.nodes.Add(v205607);
            this.nodes.Add(v205608);
            this.nodes.Add(v205609);
            this.nodes.Add(v20561);
            this.nodes.Add(v205611);
            this.nodes.Add(v205612);
            this.nodes.Add(v205613);
            this.nodes.Add(v205614);
            this.nodes.Add(v205615);
            this.nodes.Add(v205616);
            this.nodes.Add(v205617);
            this.nodes.Add(v205618);
            this.nodes.Add(v205619);
            this.nodes.Add(v20562);
            this.nodes.Add(v205621);
            this.nodes.Add(v205622);
            this.nodes.Add(v205623);
            this.nodes.Add(v205624);
            this.nodes.Add(v205625);
            this.nodes.Add(v205626);
            this.nodes.Add(v205627);
            this.nodes.Add(v205628);
            this.nodes.Add(v205629);
            this.nodes.Add(v20563);
            this.nodes.Add(v205631);
            this.nodes.Add(v205632);
            this.nodes.Add(v205633);
            this.nodes.Add(v205634);
            this.nodes.Add(v205635);
            this.nodes.Add(v205636);
            this.nodes.Add(v205637);
            this.nodes.Add(v205638);
            this.nodes.Add(v205639);
            this.nodes.Add(v20564);
            this.nodes.Add(v205641);
            this.nodes.Add(v205642);
            this.nodes.Add(v205643);
            this.nodes.Add(v205644);
            this.nodes.Add(v205645);
            this.nodes.Add(v205646);
            this.nodes.Add(v205647);
            this.nodes.Add(v205648);
            this.nodes.Add(v205649);
            this.nodes.Add(v20565);
            this.nodes.Add(v205651);
            this.nodes.Add(v205652);
            this.nodes.Add(v205653);
            this.nodes.Add(v205654);
            this.nodes.Add(v205655);
            this.nodes.Add(v205656);
            this.nodes.Add(v205657);
            this.nodes.Add(v205658);
            this.nodes.Add(v205659);
            this.nodes.Add(v20566);
            this.nodes.Add(v2057);
            this.nodes.Add(v2058);
            this.nodes.Add(v2059);
            this.nodes.Add(v2060);
            this.nodes.Add(v2061);
            this.nodes.Add(v2062);
            this.nodes.Add(v2063);
            this.nodes.Add(v2064);
            this.nodes.Add(v2065);
            this.nodes.Add(v2066);
            this.nodes.Add(v2068);
            this.nodes.Add(v2070);
            this.nodes.Add(v2071);
            this.nodes.Add(v2072);
            this.nodes.Add(v2073);
            this.nodes.Add(v207501);
            this.nodes.Add(v207502);
            this.nodes.Add(v207503);
            this.nodes.Add(v207504);
            this.nodes.Add(v2077);
            this.nodes.Add(v2078);
            this.nodes.Add(v2079);
            this.nodes.Add(v2080);
            this.nodes.Add(v208101);
            this.nodes.Add(v208102);
            this.nodes.Add(v208103);
            this.nodes.Add(v208104);
            this.nodes.Add(v208105);
            this.nodes.Add(v208106);
            this.nodes.Add(v208107);
            this.nodes.Add(v208108);
            this.nodes.Add(v208109);
            this.nodes.Add(v20811);
            this.nodes.Add(v208111);
            this.nodes.Add(v208112);
            this.nodes.Add(v208113);
            this.nodes.Add(v208114);
            this.nodes.Add(v2082);
            this.nodes.Add(v2084);
            this.nodes.Add(v2085);
            this.nodes.Add(v2086);
            this.nodes.Add(v2087);
            this.nodes.Add(v2088);
            this.nodes.Add(v2089);
            this.nodes.Add(v2090);
            this.nodes.Add(v2091);
            this.nodes.Add(v2092);
            this.nodes.Add(v2094);
            this.nodes.Add(v2095);
            this.nodes.Add(v2096);
            this.nodes.Add(v209701);
            this.nodes.Add(v209702);
            this.nodes.Add(v209703);
            this.nodes.Add(v209704);
            this.nodes.Add(v209705);
            this.nodes.Add(v209706);
            this.nodes.Add(v209707);
            this.nodes.Add(v209708);
            this.nodes.Add(v209709);
            this.nodes.Add(v20971);
            this.nodes.Add(v209711);
            this.nodes.Add(v209712);
            this.nodes.Add(v209713);
            this.nodes.Add(v209714);
            this.nodes.Add(v209715);
            this.nodes.Add(v209716);
            this.nodes.Add(v209717);
            this.nodes.Add(v209718);
            this.nodes.Add(v209719);
            this.nodes.Add(v2099);
            this.nodes.Add(v2100);
            this.nodes.Add(v2101);
            this.nodes.Add(v2102);
            this.nodes.Add(v2105);
            this.nodes.Add(v2106);
            this.nodes.Add(v2107);
            this.nodes.Add(v2108);
            this.nodes.Add(v2109);
            #endregion

        }



        public void addData(List<Person> data)
        {
            foreach (Person p in data)
            {

                Vertex v = findVertex(p.deskNo);
                if (v == null)
                    continue;
                v.info = p;
            }
        }

        public  Vertex findVertex(string n)
        {
            foreach(Vertex v in this.nodes) {
                if (v.name == n)
                    return v;
            }
            return null;
        }

        public void buildGraph()
        { Vertex a = new Vertex(Int32.MaxValue, "A", 10, 10);
           
            Vertex b = new Vertex(Int32.MaxValue, "B", 322, 40);
            Vertex c = new Vertex(Int32.MaxValue, "C", 244, 120);
            Vertex d = new Vertex(Int32.MaxValue, "D", 75, 234);
            Vertex e = new Vertex(Int32.MaxValue, "E", 178, 346);
            Vertex f = new Vertex(Int32.MaxValue, "F", 123, 333);

            
            Edge ab = new Edge(ref b, 7);
            Edge ac = new Edge(ref c, 9);
            Edge af = new Edge(ref f, 14);
            a.addNeighbors(ref ab);
            a.addNeighbors(ref ac);
            a.addNeighbors(ref af);

            Edge ba = new Edge(ref a, 7);
            Edge bc = new Edge(ref c, 10);
            Edge bd = new Edge(ref d, 15);
            b.addNeighbors(ref ba);
            b.addNeighbors(ref bc);
            b.addNeighbors(ref bd);

            Edge cf = new Edge(ref f, 2);
            Edge ca = new Edge(ref a, 9);
            Edge cb = new Edge(ref b, 10);
            Edge cd = new Edge(ref d, 11);
            c.addNeighbors(ref cf);
            c.addNeighbors(ref ca);
            c.addNeighbors(ref cb);
            c.addNeighbors(ref cd);

            Edge de = new Edge(ref e, 6);
            Edge dc = new Edge(ref c, 11);
            Edge db = new Edge(ref b, 15);
            d.addNeighbors(ref de);
            d.addNeighbors(ref dc);
            d.addNeighbors(ref db);

            Edge ed = new Edge(ref d, 6);
            Edge ef = new Edge(ref f, 9);
            e.addNeighbors(ref ed);
            e.addNeighbors(ref ef);

            Edge fa = new Edge(ref a, 14);
            Edge fc = new Edge(ref c, 2);
            Edge fe = new Edge(ref e, 9);
            f.addNeighbors(ref fa);
            f.addNeighbors(ref fc);
            f.addNeighbors(ref fe);

            this.nodes.Add(a);
            this.nodes.Add(b);
            this.nodes.Add(c);
            this.nodes.Add(d);
            this.nodes.Add(e);
            this.nodes.Add(f);

        }

        public Graph readyForJSON()
        {
            Graph retG = new Graph(this);
            string s = "";
            foreach (Vertex v in retG.nodes)
            {
                //System.Diagnostics.Debug.WriteLine(v.name);
                

                s = "";
                foreach (Edge e in v.neighbors)
                {
                    
                    s += e.neighbor.name + " ";
                }
                v.ListOfNeighbors = s;

                v.neighbors = null;
            }
            return retG;
        }
        // s = source, t = target
        public string FSP(string s, string t)
        {
            List<Vertex> unvisited = new List<Vertex>();
            Vertex source = null;
            Vertex target = null;
            Vertex curr = null;

            //find source and target
            foreach (Vertex v in this.nodes)
            {
                if (!v.name.Contains("travel"))
                {
                    if (v.info.deskNo == s)
                    {
                        System.Diagnostics.Debug.WriteLine("Source found");
                        source = v;
                        v.distance = 0;
                    }
                    if (v.info.deskNo == t)
                    {
                        System.Diagnostics.Debug.WriteLine("Target found");
                        target = v;
                        v.distance = Int32.MaxValue;
                    }
                }
                else
                {
                    v.distance = Int32.MaxValue;

                }
                unvisited.Add(v);
            }


            while (unvisited.Count != 0)
            {
                //Select node with min distance
                curr = unvisited.OrderBy(g => g.distance).First();
                System.Diagnostics.Debug.WriteLine(curr.name);

                //remove current node from unvisited
                unvisited.Remove(curr);
                foreach (Edge e in curr.neighbors)
                {
                    //System.Diagnostics.Debug.WriteLine("looking at neighbors");
                    //System.Diagnostics.Debug.WriteLine(e.neighbor.name);
                    Vertex neighbor = e.neighbor;
                    if (neighbor.visited)
                        continue;
                    int dis = curr.distance + e.weight;
                    if (dis < neighbor.distance)
                    {
                        neighbor.distance = dis;
                        neighbor.previous = curr;
                    }
                }
                curr.visited = true;
            }



            //System.Diagnostics.Debug.WriteLine("End last node before is " + target.previous.name);
            Vertex temp = target;
            string retPath = temp.name;
            while (temp.previous != null)
            {
                //System.Diagnostics.Debug.WriteLine("Path backwards is " + temp.previous.name);
                temp = temp.previous;
                retPath += " " + temp.name;
            }

            return drawPath(target);
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string drawPath(Vertex target) {
            string path = "";
            bool entryStairs = true;
            while (target != null)
            {
                if (target.info != null)
                {
                    if (target.info.fName.Contains("Stair") && entryStairs)
                    {
                        path = "Stair " + "M" + target.midX.ToString() + " " + target.midY.ToString() + " " + path;
                        target = target.previous;
                        entryStairs = false;
                        continue;
                    }
                }
                

                if (target.previous == null)
                {
                    path = "M" + target.midX.ToString() + " " + target.midY.ToString() + " " + path;
                }
                else
                {
                    path = "L" + target.midX.ToString() + " " + target.midY.ToString() + " " + path;
                }

                
                target = target.previous;
            }

            return path;
        }

    }
}
