import * as React from "react";
import * as ReactDOM from "react-dom";
import { Toggle } from "components";
import { Table, Button } from "react-bootstrap";
import axios from 'axios';

interface GolferShape {
    membershipId?: string,
    firstName?: string,
    lastName?: string,
    handicap?: number,
    isAdmin?: boolean,
    isActive?: boolean
}

interface GolfersProps {
    golfers: Array<GolferShape>
}

interface GolfersState {
    golfers: Array<GolferShape>
}

class Golfers extends React.Component<GolfersProps, GolfersState> {

    constructor(props: GolfersProps) {
        super(props);
        this.state = {
            golfers: this.props.golfers
        }
    }

    componentDidMount() {
        axios.get("GetAllGolfers").then(r => {
            this.setState({
                golfers: r.data
            })
        }).catch(r => alert("Could not fetch golfers!"));
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
                            <tr key={g.membershipId}>
                                <td>{g.membershipId}</td>
                                <td>{g.firstName} {g.lastName}</td>
                                <td>{g.handicap}</td>
                                <td>
                                    <Toggle offstyle="danger" active={g.isActive} />
                                </td>
                                <td>
                                    <Button>Edit</Button>
                                    <Button>Delete</Button>
                                </td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
        )
    }
}

ReactDOM.render(<Golfers golfers={[]} />, document.getElementById("react-app"));