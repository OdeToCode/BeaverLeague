import * as React from "react";
import * as ReactDOM from "react-dom";
import { Grid, Row, Col, Table, ListGroup, ListGroupItem, Panel, Button } from "react-bootstrap";
import { api, parameters } from "services";
import { IGolfer } from "models";


interface IEditMatchSetProps {
    matchSetId: number;
}

interface IEditMatchSetState {
    golfers: IGolfer[]
}

interface IGolferListProps {
    name: string; 
    golfers: Array<IGolfer>; 
}

const GolferList = (props: IGolferListProps) => 
    <Panel header={<h3>{props.name}</h3>} bsStyle="primary">
        <Table condensed hover>
            <tbody>
            {
                props.golfers.map(g => (            
                    <tr key={g.id}><td>{g.firstName} {g.lastName}</td></tr>
                ))
            }
            </tbody>
        </Table>
    </Panel>

class EditMatchSet extends React.Component<IEditMatchSetProps, IEditMatchSetState> {

    constructor(props : IGolferListProps) {
        super(props);
        this.state = {
            golfers: []
        }
    }

    async componentDidMount() {
        let golfers = await api.getActiveGolfers();        
        this.setState({ golfers: golfers });
    }

    render() {
        return (
            <Grid fluid={true}>
                <Row>
                    <Col sm={12}>

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
                        <Panel header={<h3>Matchups</h3>} bsStyle="primary">
                            <ListGroup>
                                <ListGroupItem>
                                    <i className="fa fa-remove pull-right" />
                                    <small><div>Scott Allen vs</div><div> Bob Socks</div></small>                                    
                                </ListGroupItem>
                            </ListGroup>
                        </Panel>
                    </Col>
                    <Col sm={3}>
                        <Panel header={<h3>Inactive This Week</h3>} bsStyle="primary">
                            <ListGroup>
                                <ListGroupItem>
                                    <i className="fa fa-remove pull-right" />
                                    Jason Nye
                                </ListGroupItem>
                            </ListGroup>
                        </Panel>
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