import * as React from "react";
import * as ReactDOM from "react-dom";
import {Toggle, Table, Column} from "components";
import axios from 'axios';

interface GolferShape {
    membershipId?: string,
    firstName?: string,
    lastName?: string,
    handicap?: number,
    isAdmin?: boolean,
    isActive?: boolean
}


class GolfersTable extends Table<GolferShape> {    

}

class GolfersColumn extends Column<GolferShape> {

}

interface ManageGolfersListProps {
    golfers: Array<GolferShape>
}

interface ManageGolfersStateProps {
    golfers: Array<GolferShape>
}

class ManageGolfersList extends React.Component<ManageGolfersListProps, ManageGolfersStateProps> {

    constructor(props) {
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
        return (
            <GolfersTable data={this.state.golfers}>
                <GolfersColumn header="Membership #" cell={g => g.membershipId}>
                </GolfersColumn>
                <GolfersColumn header="Name" cell={g => `${g.firstName} ${g.lastName}`}>
                </GolfersColumn>
                <GolfersColumn header="Handicap" cell={g => g.handicap}>
                </GolfersColumn>
                <GolfersColumn header="Admin" cell={g => <Toggle value={g.isAdmin} />}>
                </GolfersColumn>
                <GolfersColumn header="Active*" cell={g => <Toggle value={g.isActive} />}>
                </GolfersColumn>
                <GolfersColumn header="Actions" cell={
                    <div>
                        <a className="btn btn-default">Edit</a>
                        <a className="btn btn-default">Delete</a>
                    </div>
                }>
                </GolfersColumn>
            </GolfersTable>

        )
    }
}

ReactDOM.render(<ManageGolfersList golfers={[]} />, document.getElementById("react-app"));