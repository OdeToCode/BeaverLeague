import * as React from "React";

interface SliderProps {
    value: boolean
}

export class Toggle extends React.Component<any, any> {
    render() {
        return (
            <div className="toggle btn btn-primary on">
                <input type="check" value={this.props.value} />
            </div>
        )
    }
}