﻿using System.Web;
using System.Web.Optimization;

namespace OgrenciNotMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/style4.css"));
        }
    }
}
