# AzureAppInsights_Sample

Sample of how to add App Insights connectivity to a SPA application to allow that frontend (React) and backend (NET 6.0) send trace, errors, pageViews, etc. to Azure through ILogger.

## Requirements
An AppInsights resource (Oh Surprise!) created in Azure where we will get the **Connection String or InstrumentationKey**

## React
At first we need install these packages
```
npm i --save @microsoft/applicationinsights-react-js @microsoft/applicationinsights-web
```

Add the file under **src/Service/AppInsight.js**, here we use our ConnectionString. By default AppInsights register PageViews, Dependencies and others logs, but if we import the service inside other components we can send our custom traces or errors. For example inside the **App.js** render:
```
import { appInsights } from './Services/AppInsight';

export default class App extends Component {
    static displayName = App.name;

    render() {
        appInsights.trackTrace({ message: 'Render!' });
        return (
            <Layout>
                <Route exact path='/' component={Home} />
            </Layout>
        );
    }
}
```

## NET 6.0
Here we can choose different ways (the VS2022 wizard for example), in this case we setup the AppInsights explicity in **Program.cs** (Old Startup.cs in Core 3.1)

Install the following NuGet package **Microsoft.ApplicationInsights.AspNetCore**

Edit your appSettings.json to look like this:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Warning",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    },
    "ApplicationInsights": {
      "LogLevel": {
        "Default": "Warning",
        "System": "Warning",
        "Microsoft": "Warning",
        "Microsoft.Hosting.Lifetime": "Information"
      }
    }
  },
  "ApplicationInsights": {
    "ConnectionString": "<Your-ConnectionString-Here>",
    "EnableAdaptiveSampling": true
  },
  "AllowedHosts": "*",
  "OtherSetting1": "value123",
  "OtherSetting2": "value456"
}
```

Add this block code in **Program.cs**
```
// Add ApplicationInsights settings
builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = builder.Configuration["ApplicationInsights:ConnectionString"];
    options.EnableAdaptiveSampling = Convert.ToBoolean(builder.Configuration["ApplicationInsights:EnableAdaptiveSampling"]);
});

```

At this point **AppInsights** can log request to our APIs, System Info, etc. but we also can send, for example custom error messages, this is the way:

```
catch (Exception ex)
{
  _logger.LogError($"An error occurred in the GET method - {ex}");
}
```
