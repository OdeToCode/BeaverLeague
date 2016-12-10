import * as React from "react";
import * as ReactDOM from "react-dom";
import { Grid, Row, Col, Table, ListGroup, ListGroupItem, Panel, Button } from "react-bootstrap";
import { api, parameters } from "services";
import { IGolfer, IMatchSet, IMatch } from "models";

interface InactiveDescription {
    id: number; 
    firstName: string; 
    lastName: string;
}

interface IEditMatchSetProps {
    matchSetId: number;
}

interface IEditMatchSetState {
    golfers: IGolfer[];
    matchset: IMatchSet;
    inactives: InactiveDescription[]
}

interface IGolferListProps {
    name: string;
    golfers: Array<IGolfer>;
}

interface IInactiveListProps {
    inactives: InactiveDescription[];
}

interface IMatchListProps {
    matches: IMatch[]
}

const GolferList = (props: IGolferListProps) =>
    <Panel header={<h3>{props.name}</h3>} bsStyle="primary">
        <Table condensed hover>
            <tbody>
                {
                    props.golfers.map(g => 
                        <tr key={g.id}><td>{g.firstName} {g.lastName}</td></tr>
                    )
                }
            </tbody>
        </Table>
    </Panel>

const InactiveList = (props: IInactiveListProps) =>
    <Panel header={<h3>Inactive This Week</h3>} bsStyle="primary">
        <Table condensed hover>
            <tbody>
                {
                    props.inactives.map(i => 
                        <tr key={i.id}><td>{i.firstName} {i.lastName}</td></tr>
                    )
                }
            </tbody>
            
            <ListGroupItem>
                <i className="fa fa-remove pull-right" />
                Jason Nye
            </ListGroupItem>
        </Table>
    </Panel>

const MatchList = (props: IMatchListProps) =>
    <Panel header={<h3>Matchups</h3>} bsStyle="primary">
        <Table condensed hover>
            <tbody>
                {
                    props.matches.map(m => 
                        <tr key={m.id}>
                            <td>
                                <small><div>{m.golferA.firstName} {m.golferA.lastName} vs</div>
                                    <div>{m.golferB.firstName} {m.golferB.lastName}</div>
                                </small>
                            </td>
                        </tr>
                    )
                }
            </tbody>
        </Table>
    </Panel>

class EditMatchSet extends React.Component<IEditMatchSetProps, IEditMatchSetState> {

    constructor(props: IGolferListProps) {
        super(props);
        this.state = {
            golfers: [],
            matchset: {
                id: null,
                seasonId: null,
                matchSetNumber: null,
                inactives: [],
                matches: []
            },
            inactives: []
        }
    }

    async componentDidMount() {
        let golfers = await api.getActiveGolfers();
        let matchset = await api.getMatchSet(this.props.matchSetId);
        this.calculateState(golfers, matchset);
    }

    calculateState(golfers: IGolfer[], matchset: IMatchSet) {

    }

    render() {
        return (
            <Grid fluid={true}>
                <Row>
                    <Col sm={12}>
                        <h3 className="text-center">
                            Week # {this.state.matchset.matchSetNumber}
                        </h3>
                    </Col>
                </Row>
                <Row>
                    <Col sm={3}>
                        <GolferList name="Golfer A" golfers={this.state.golfers} />
                    </Col>
                    <Col sm={3}>
                        <GolferList name="Golfer B" golfers={this.state.golfers} />
                    </Col>
                    <Col sm={3}>
                        <MatchList matches={this.state.matchset.matches} />
                    </Col>
                    <Col sm={3}>
                        <InactiveList inactives={this.state.inactives} />
                    </Col>
                </Row>
                <Row>
                    <Button bsStyle="primary">Run AutoMatcher!</Button>
                </Row>
            </Grid>
        );
    }
}

const elementName = "react-creatematchset";
const element = document.getElementById(elementName)
const props = parameters(element);
ReactDOM.render(<EditMatchSet matchSetId={props.matchSetId} />, element);