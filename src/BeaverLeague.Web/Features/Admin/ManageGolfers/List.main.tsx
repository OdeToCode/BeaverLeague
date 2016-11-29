import * as React from "react";
import * as ReactDOM from "react-dom";
import thunk from "redux-thunk";
import axios from 'axios';
import {Provider, connect} from "react-redux";
import {createStore, applyMiddleware, 
        combineReducers, Dispatch} from "redux";

const enum ActionTypes {
    LoadGolfersSuccess
}

const initialState = {
    golfers: [] as any
}

const loadGolfersSuccess = (response: any) => (
    {type: ActionTypes.LoadGolfersSuccess, golfers: response.data}
);

const loadGolfers = (dispatch : any) => {
    return axios.get("GetAllGolfers")
                .then(golfers => dispatch(loadGolfersSuccess(golfers)))
}

const golfersReducer = (state: any = initialState.golfers, action: any) => {
    switch(action.type) {
        case ActionTypes.LoadGolfersSuccess:
            return action.golfers;
        default:
            return state;
    }
};

const rootReducer = combineReducers({
    golfers: golfersReducer    
});

const store = createStore(rootReducer, applyMiddleware(thunk));
store.dispatch(loadGolfers);

class GolferPage extends React.Component<any, any> {

    static propTypes = {
        golfers: React.PropTypes.array.isRequired
    }

    render() {
        return <table className="table table-condensed table-hover">
                <thead>
                <tr>
                    <th>Member #</th>
                    <th>Name</th>
                    <th>Handicap</th>
                    <th>Admin</th>
                    <th>Active*</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                { this.props.golfers.map((g:any) => 
                    <tr>
                        <td>{g.membershipId}</td>
                        <td>@golfer.LastName, @golfer.FirstName</td>
                        <td>@golfer.Handicap</td>
                        <td>@golfer.IsAdmin</td>
                        <td>@golfer.IsActive</td>
                        <td>
                            <a className="btn btn-default" asp-action="Edit" asp-route-id="@golfer.Id">Edit</a>
                            <a className="btn btn-default">Delete</a>
                        </td>
                    </tr>                  
                )} 
                </tbody>
            </table>
    }
}

function mapStateToProps(state:any , ownProps:any) {
    return {
        golfers: state.golfers
    }
} 

const ConnectedGolferPage = connect(mapStateToProps)(GolferPage);  

ReactDOM.render(<Provider store={store}>
                    <ConnectedGolferPage />
                </Provider>, document.getElementById("react-app"));