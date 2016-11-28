import * as React from "react";
import * as ReactDOM from "react-dom";

class App extends React.Component<any, any> {
    render() {
        return <h3>Hello!</h3>;
    }
}

ReactDOM.render(<App/>, document.querySelector("App"));
console.log("done");