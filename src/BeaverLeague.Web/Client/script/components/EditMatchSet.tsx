import * as React from "react";
import { Grid, Row, Col, Table, ListGroup, ListGroupItem, Panel, Button } from "react-bootstrap";
import { IGolfer, IMatchSet, IMatch, EditMatchSetStore, IEditMatchSetState, IInactiveDescription, ISelectableGolfer } from "models";

interface IEditMatchSetProps {
    matchSetId: number;
}

interface IGolferListProps {
    name: string;
    golfers: Array<ISelectableGolfer>;
    selectGolfer: (g:IGolfer) => void;
}

interface IInactiveListProps {
    inactives: IInactiveDescription[];
}

interface IMatchListProps {
    matches: IMatch[]
}

const isSelected = (golfer: ISelectableGolfer) => 
    golfer.isSelected ? "information" : ""

const GolferList = (props: IGolferListProps) =>
    <Panel header={<h3>{props.name}</h3>} bsStyle="primary">
        <Table condensed hover>
            <tbody>
                {
                    props.golfers.map(g => 
                        <tr key={g.id} onClick={() => props.selectGolfer(g)} className={isSelected(g)}>
                            <td>{g.firstName} {g.lastName}</td>
                        </tr>
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
                                <div>{m.golferA.firstName} {m.golferA.lastName} vs</div>
                                <div>{m.golferB.firstName} {m.golferB.lastName}</div>
                            </td>
                        </tr>
                    )
                }
            </tbody>
        </Table>
    </Panel>

export class EditMatchSet extends React.Component<IEditMatchSetProps, IEditMatchSetState> {

    store: EditMatchSetStore;

    constructor(props: IEditMatchSetProps) {
        super(props);
        this.store = new EditMatchSetStore(this);
        this.state = this.store.produceState();
    }

    componentDidMount() {
        this.store.load(this.props.matchSetId);
    }

    render() {
        const store = this.store, state = this.state;
        return (
            <Grid fluid={true}>
                <Row>
                    <Col sm={12}>
                        <h3 className="text-center">
                            Week # {state.matchset.matchSetNumber}
                        </h3>
                    </Col>
                </Row>
                <Row>
                    <Col sm={4}>
                        <GolferList name="Golfers" golfers={state.golfers} 
                                    selectGolfer={(g) => store.selectGolfer(g) }/>
                    </Col>
                    <Col sm={4}>
                        <MatchList matches={state.matchset.matches} />
                    </Col>
                    <Col sm={4}>
                        <InactiveList inactives={state.inactives} />
                    </Col>
                </Row>
                <Row>
                    <Button bsStyle="primary">Run AutoMatcher!</Button>
                </Row>
            </Grid>
        );
    }
}