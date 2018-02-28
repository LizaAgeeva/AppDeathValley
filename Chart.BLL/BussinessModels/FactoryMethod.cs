using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chart.BLL.BussinessModels
{
    public class FactoryMethod
    {
        public string typeChart;
        public FactoryMethod(string type)
        {
            if (type == "Line")
            {

                Plotter plotter = new LineChartPlotter();
                Graph lineGraph = plotter.Create(type);
                typeChart = lineGraph.CreateGraph();
            }
            if (type == "Pie")
            {

                Plotter plotter = new PieChartPlotter();
                Graph pieGraph = plotter.Create(type);
                typeChart = pieGraph.CreateGraph();
            }
           
        }
        abstract class Graph
        {
            public abstract string CreateGraph();

        }

        abstract class Plotter
        {

            public Plotter()
            { }
            
            
            abstract public Graph Create(string type);
        }

        class LineChartPlotter : Plotter
        {
            public LineChartPlotter() : base()
            { }

            public override Graph Create(string type)
            {
                return new LineChart();
            }
        }
        class PieChartPlotter : Plotter
        {
            public PieChartPlotter() : base()
            { }

            public override Graph Create(string type)
            {
                return new PieChart();
            }
        }
       

        class LineChart : Graph
        {
            private string typeChart;
            public LineChart()
            {
                
                typeChart = "Line Chart Create";
            }
            public override string CreateGraph()
            {
                return typeChart;
            }
        }

        class PieChart : Graph
        {
            private string typeChart;
            public PieChart()
            {
                typeChart = "Pie Chart Create";
            }
            public override string CreateGraph()
            {
                return typeChart;
            }
        }
    }
}
