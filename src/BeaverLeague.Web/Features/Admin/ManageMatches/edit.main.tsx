import {EditMatchSet} from "components";
import {parameters} from "services";
import * as ReactDOM from "react-dom";
import * as React from "react";

const elementName = "react-creatematchset";
const element = document.getElementById(elementName)
const props = parameters(element);
ReactDOM.render(<EditMatchSet matchSetId={props.matchSetId} />, element);