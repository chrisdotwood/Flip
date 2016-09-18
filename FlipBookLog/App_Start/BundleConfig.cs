﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Flip {
	public class BundleConfig {
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles) {
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
				"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.unobtrusive*",
				"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/app").Include(
				"~/Scripts/angular.js",
				"~/Scripts/angular-route*",
				"~/App/app.js",
				"~/App/loginController.js",
				"~/App/reviewController.js",
				"~/App/Services/authenticationInterceptorService.js",
				"~/App/Services/authenticationService.js"
			));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
				"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				"~/Scripts/bootstrap.js",
				"~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
				 "~/Content/bootstrap.css",
				 "~/Content/Site.css"));
		}
	}
}
