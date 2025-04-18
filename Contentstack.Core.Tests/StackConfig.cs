﻿using System;
using System.Configuration;
using Microsoft.Extensions.Options;
using Contentstack.Core.Configuration;

namespace Contentstack.Core.Tests
{

    public class StackConfig
    {
        System.Configuration.Configuration currentConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        System.Configuration.Configuration assemblyConfiguration
        {
            get
            {
                return ConfigurationManager.OpenExeConfiguration(new Uri(uriString: GetType().Assembly.CodeBase).LocalPath);
            }
        }

        public static ContentstackClient GetStack()
        {
            StackConfig config = new StackConfig();
            if (config.assemblyConfiguration.HasFile && string.Compare(config.assemblyConfiguration.FilePath, config.currentConfiguration.FilePath, true) != 0)
            {
                config.assemblyConfiguration.SaveAs(config.currentConfiguration.FilePath);
                ConfigurationManager.RefreshSection("appSettings");
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            string apiKey = ConfigurationManager.AppSettings["api_key"];
            string delivery_token = ConfigurationManager.AppSettings["delivery_token"];
            string environment = ConfigurationManager.AppSettings["environment"];
            string host = ConfigurationManager.AppSettings["host"];
            Configuration.ContentstackOptions contentstackOptions = new Configuration.ContentstackOptions
            {
                ApiKey = apiKey,
                DeliveryToken = delivery_token,
                Environment = environment,
                Host = host,
                Timeout = 4500,
                 //Proxy = new System.Net.WebProxy("http://example.com:8080")
            };

            ContentstackClient contentstackClient = new ContentstackClient(new OptionsWrapper<Configuration.ContentstackOptions>(contentstackOptions));
            
            return contentstackClient;

        }

        public static ContentstackClient GetLPStack()
        {
            StackConfig config = new StackConfig();
            if (config.assemblyConfiguration.HasFile && string.Compare(config.assemblyConfiguration.FilePath, config.currentConfiguration.FilePath, true) != 0)
            {
                config.assemblyConfiguration.SaveAs(config.currentConfiguration.FilePath);
                ConfigurationManager.RefreshSection("appSettings");
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            string apiKey = ConfigurationManager.AppSettings["api_key"];
            string delivery_token = ConfigurationManager.AppSettings["delivery_token"];
            string environment = ConfigurationManager.AppSettings["environment"];
            string host = ConfigurationManager.AppSettings["host"];
            Configuration.ContentstackOptions contentstackOptions = new Configuration.ContentstackOptions
            {
                ApiKey = apiKey,
                DeliveryToken = delivery_token,
                Environment = environment,
                Host = host,
                Timeout = 4500,
                LivePreview = new LivePreviewConfig
                {
                    Enable = true,
                    PreviewToken = "preview_token", // Replace with a valid preview token
                    Host = "test_host" // Replace with a valid preview host (e.g., "rest-preview.contentstack.com")
                }
                //Proxy = new System.Net.WebProxy("http://example.com:8080")
            };

            ContentstackClient contentstackClient = new ContentstackClient(new OptionsWrapper<Configuration.ContentstackOptions>(contentstackOptions));

            return contentstackClient;

        }
    }
}
