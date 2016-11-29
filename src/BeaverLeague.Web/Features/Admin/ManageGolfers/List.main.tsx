import * as React from "react";
import * as ReactDOM from "react-dom";

const App = () => <Grid></Grid>;

class Grid extends React.Component<any, any> {
    render() {
        return <div>Grid</div>;
    }
}

ReactDOM.render(<App></App>, document.querySelector("App"));