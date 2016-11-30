import * as React from "react";
import * as ReactDOM from "react-dom";

interface ColumnProps<T> {
    header: string | React.ReactElement<any> | HeaderFactory 
    cell: string | React.ReactElement<any> | CellFactory<T> 
}

interface TableProps<T> {
    data: T[];
    children?: Array<ColumnComponent<T>>
}

interface HeaderFactory {
    () : Element
}

interface CellFactory<T> {
    (dataRow: T) : any
}

type ColumnComponent<T> = React.Component<ColumnProps<T>, any>
type ColumnsCollection<T> = Array<ColumnComponent<T>>;
type ExpressionType<T> = string | React.ReactElement<any> | CellFactory<T>

function renderExpression<T>(expression: ExpressionType<T>, data?: T)  {
    if (typeof (expression) === "function") {
        return expression(data);
    }
    return expression;
}

function renderHeaderRow<T>(columns: ColumnsCollection<T>) {
    return <tr>{columns.map((c, i) => <th key={i}>{renderExpression(c.props.header)}</th>)}</tr>
}

function renderCells<T>(dataRow: T, columns: ColumnsCollection<T>) {
    return columns.map((c, i) => <td key={i}>{renderExpression(c.props.cell, dataRow)}</td>)
}

function renderDataRows<T>(data: Array<any>, columns: ColumnsCollection<T>) {
    return data.map((row, i) => <tr key={i}>{renderCells(row, columns)}</tr>);
}

export class Table<T> extends React.Component<TableProps<T>, any> {
    props: TableProps<T>;
    render() {
        const props = this.props;
        return (
            <table className="table table-condensed table-hover">
                <thead>
                    {renderHeaderRow(props.children)}
                </thead>
                <tbody>
                    {renderDataRows(props.data, props.children)}
                </tbody>
            </table>
        )
    }
}

export class Column<T> extends React.Component<ColumnProps<T>, any> {
    props: ColumnProps<T>;
    render() {
        return <h3>This should not render</h3>
    }
}  