using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace VisualSearch
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml.
  /// </summary>
  public partial class MainWindow : Window
  {

		#region My Subscription Key

		const string SubscriptionKey = "MY KEY";

    #endregion

    const string UriBase = "https://api.bing.microsoft.com/v7.0/images/search";

    public MainWindow()
    {
      InitializeComponent();
    }

    private void SearchTermsTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      // If there is a valid string in the text box, search for some images.
      // A valid string is any group of characters - even just one, except empty spaces.
      if (e.Key == Key.Enter && searchTermsTextBox.Text.Trim().Length > 0)
      {
        string imageUrl = FindUrlOfImage(searchTermsTextBox.Text);

        foundObjectImage.Source = new BitmapImage(new Uri(imageUrl, UriKind.Absolute));
      }
    }

    struct SearchResult
    {
      public String jsonResult;
      public Dictionary<String, String> relevantHeaders;
    }

    private string FindUrlOfImage(string targetString)
    {
      // Call the method that does the search.
      SearchResult result = PerformBingImageSearch(targetString);

      // Process the JSON response from the Bing Image Search API
      // and get the URL of the first image returned.
      var jResult = JObject.Parse(result.jsonResult);

      // Extract an array of "values" (search hits) from the large object returned.
      JArray values = (JArray)jResult["value"];

      // Take the first value as a string and parse it into components.
      if (values.Count > 0)
      {
        string firstResult = values[0].ToString();
        JObject jFirst = JObject.Parse(firstResult);

        // Extract the content string from the components and return it as an image URL.
        string imageUrl = (string)jFirst["contentUrl"];
        return imageUrl;
      }
      else
      {
        return "https://docs.microsoft.com/learn/windows/build-internet-connected-windows10-apps/media/imagenotfound.png";
      }
    }

    static SearchResult PerformBingImageSearch(string searchTerms)
    {
      // Create the web-based query that talks to the Bing API.
      string uriQuery = $"{UriBase}?q={Uri.EscapeDataString(searchTerms)}";
      WebRequest request = WebRequest.Create(uriQuery);
      request.Headers["Ocp-Apim-Subscription-Key"] = SubscriptionKey;
      HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
      string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

      // Create the result object for the return value.
      var searchResult = new SearchResult()
      {
        jsonResult = json,
        relevantHeaders = new Dictionary<String, String>()
      };

      // Extract the Bing HTTP headers.
      foreach (String header in response.Headers)
      {
        if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
        {
          searchResult.relevantHeaders[header] = response.Headers[header];
        }
      }

      return searchResult;
    }

  }
}