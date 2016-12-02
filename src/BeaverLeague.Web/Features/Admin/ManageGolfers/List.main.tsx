import * as React from "react";
import * as ReactDOM from "react-dom";
import { Toggle } from "components";
import { Table, Button } from "react-bootstrap";
import {api} from "services";

interface IGolferShape {
    id: number;
    membershipId: string;
    firstName: string;
    lastName: string;
    handicap: number;
    isAdmin: boolean;
    isActive: boolean;
}

interface IGolfersProps {
    golfers: Array<IGolferShape>
}

interface IGolfersState {
    golfers: Array<IGolferShape>
}
   
class Golfers extends React.Component<IGolfersProps, IGolfersState> {

    constructor(props: IGolfersProps) {
        super(props);
        this.state = {
            golfers: this.props.golfers
        }
    }

    componentDidMount() {
        api.getAllGolfers()
            .then((data: Array<IGolferShape>) => { this.setState({ golfers: data }) });           
    }

    setGolferActiveFlag(golfer: IGolferShape, value: boolean) {
        golfer.isActive = value;
        api.setGolferActiveFlag({id: golfer.id, value}, golfer.lastName);        
    }

    render() {
        const state = this.state;

        return (
            <Table hover condensed>
                <thead>
                    <tr>
                        <th>Member #</th>
                        <th>Name</th>
                        <th>Handicap</th>
                        <th>Active*</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        state.golfers.map(g => (
                            <tr key={g.id}>
                                <td>{g.membershipId}</td>
                                <td>{g.firstName} {g.lastName}</td>
                                <td>{g.handicap}</td>
                                <td>
                                    <Toggle offstyle="danger" active={g.isActive} 
                                            onChange={(v:boolean) => this.setGolferActiveFlag(g, v) } />
                                </td>
                                <td>
                                    <Button href="Edit">Edit</Button>
                                    <Button>Delete</Button>
                                </td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
        );
    }
}

ReactDOM.render(<Golfers golfers={[]} />, document.getElementById("react-golfer-list"));