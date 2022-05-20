import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import { ReactPlugin } from '@microsoft/applicationinsights-react-js';
import { createBrowserHistory } from 'history';

const browserHistory = createBrowserHistory();
const reactPlugin = new ReactPlugin();

const appInsights = new ApplicationInsights({
    config: {
        instrumentationKey: "INSTRUMENTATION_KEY_DEV",
        extensions: [reactPlugin],
        extensionConfig: {
            [reactPlugin.identifier]: { history: browserHistory }
        },
        enableAutoRouteTracking: true,
        disableAjaxTracking: true,
        disableCookiesUsage: true
    }
});

//Load modules
appInsights.loadAppInsights();

//Send starting trace
appInsights.trackTrace({ message: 'Starting AppInsights for Frontend App' });

export { reactPlugin, appInsights };