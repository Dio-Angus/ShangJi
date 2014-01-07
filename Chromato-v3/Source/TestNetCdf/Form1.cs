using System;
using System.Windows.Forms;
using ucar.nc2;
using ucar.ma2;

namespace TestNetCdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            NetcdfFileWriteable ncfile = new NetcdfFileWriteable();

            ncfile.setName("C:\\testncfile.nc");
            Dimension latDim = ncfile.addDimension("lat", 3);
            Dimension lonDim = ncfile.addDimension("lon", 4);
            Dimension timeDim = ncfile.addDimension("time", -1);

            Dimension[] dim3 = new Dimension[3];
            dim3[0] = timeDim;
            dim3[1] = latDim;
            dim3[2] = lonDim;

            ncfile.addVariable("rh", java.lang.Integer.TYPE, dim3);
            ncfile.addVariableAttribute("rh", "long_name", "relative humidity");
            ncfile.addVariableAttribute("rh", "units", "percent");

            ncfile.addVariable("T", java.lang.Double.TYPE, dim3);
            ncfile.addVariableAttribute("T", "long_name", "surface temperature");
            ncfile.addVariableAttribute("T", "units", "degC");

            ncfile.addVariable("lat", java.lang.Float.TYPE, new Dimension[] { latDim });
            ncfile.addVariableAttribute("lat", "units", "degrees_north");

            ncfile.addVariable("lon", java.lang.Float.TYPE, new Dimension[] { lonDim });
            ncfile.addVariableAttribute("lon", "units", "degrees_east");

            ncfile.addVariable("time", java.lang.Integer.TYPE, new Dimension[] { timeDim });
            ncfile.addVariableAttribute("time", "units", "hours");

            ncfile.addGlobalAttribute("title", "Example Data");
            ncfile.create();

            Console.WriteLine("ncfile = " + ncfile);

            int[, ,] rhData = {
                              {{ 1, 2, 3, 4},
                               { 5, 6, 7, 8},
                               { 9, 10, 11, 12}},
                               {{21, 22, 23, 24},
                               {25, 26, 27, 28},
                               {29, 30, 31, 32}}};
            ArrayInt rhA = new ArrayInt.D3(2, latDim.getLength(), lonDim.getLength());

            int i, j, k;
            Index ima = rhA.getIndex();
            for (i = 0; i < 2; i++)
                for (j = 0; j < latDim.getLength(); j++)
                    for (k = 0; k < lonDim.getLength(); k++)
                        rhA.setInt(ima.set(i, j, k), rhData[i, j, k]);
            ncfile.write("rh", rhA);

            double[, ,] tData = {
                                    {
                                         { 1, 2, 3, 4},
                                         { 2, 4, 6, 8},
                                         { 3, 6, 9, 12}
                                    },
                                    {
                                        {2.5, 5, 7.5, 10}, 
                                        {5, 10, 15, 20}, 
                                        {7.5, 15, 22.5, 30}
                                    }
                                };
            ArrayDouble tA = new ArrayDouble.D3(2, latDim.getLength(), lonDim.getLength());
            ima = tA.getIndex();
            for (i = 0; i < 2; i++)
                for (j = 0; j < latDim.getLength(); j++)
                    for (k = 0; k < lonDim.getLength(); k++)
                        tA.setDouble(ima.set(i, j, k), tData[i, j, k]);

            ncfile.write("T", tA);
            ncfile.write("lat", ArrayAbstract.factory(new float[] { 41, 40, 39 }));
            ncfile.write("lon", ArrayAbstract.factory(new float[] { -109, -107, -105, -103 }));
            ncfile.write("time", ArrayAbstract.factory(new int[] { 6, 18 }));
            ncfile.close();
        }
    }
}
