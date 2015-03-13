using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.IO;
using DevExpress.XtraCharts.Web;
using DevExpress.XtraCharts;
namespace DXLiveDemo
{
	 public static class ChartUtils
	 {
		  const string palettePath = "~/App_Data";
		  const string paletteName = "MyPalette.xcp";

		  private static Palette myPalette;

		  static ChartUtils()
		  {
				myPalette = LoadPaletteFromFile();
		  }

		  private static Palette LoadPaletteFromFile()
		  {
				using (FileStream stream = new FileStream(
								HostingEnvironment.MapPath(String.Format("{0}/{1}", palettePath, paletteName)),
								FileMode.Open, FileAccess.Read))
				{
					 return DevExpress.XtraCharts.Native.PaletteSerializer.LoadFromStream(stream);
				}
		  }

		  public static void LoadMyCustomPalette(this WebChartControl control)
		  {
				control.PaletteWrappers.Add(new PaletteWrapper(myPalette));
				control.PaletteName = myPalette.Name;
		  }

		  static void SetTransparentBars(WebChartControl control, params string[] transparentBarSerieNames)
		  {
				foreach (string serieName in transparentBarSerieNames)
				{
					 var serie = (from sr in control.Series
									  where sr.Name == serieName
									  select sr).FirstOrDefault();
					 if (serie != null)
					 {
						  BarSeriesView view = serie.SeriesView as BarSeriesView;
						  if (view != null)
						  {
								view.Transparency = 120;
						  }
					 }
				}
		  }
		  public static void ApplyMyConfig(this WebChartControl control, params string[] transparentBarSerieNames)
		  {
				LoadMyCustomPalette(control);
				SetTransparentBars(control, transparentBarSerieNames);
		  }

	 }
}