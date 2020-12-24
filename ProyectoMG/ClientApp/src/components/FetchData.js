import React, { Component } from 'react';

export class FetchData extends Component {
    displayName = "Employees App";

    constructor(props) {
        super(props);
        this.state = { employees: [], loading: false, employeeId: 0 };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit= this.handleSubmit.bind(this);
    }


    getEmployees() {
        fetch('api/Employee/GetEmployees?employeeId=' + this.state.employeeId)
            .then(response => response.json())
            .then(data => this.setState({ employees: data }));
    }

    handleChange(event) {
        this.setState({ employeeId: event.target.value });
    }

    handleSubmit(event) {
        event.preventDefault();
        this.getEmployees();
    }

    render() {
        return (
            <div>
                <h1>Employees</h1>
                <form>
                    <label>
                        Employee ID: 
                        <input
                            type="number"
                            name="employeeInput"
                            placeholder="Enter employee ID here..."
                            onChange={this.handleChange}
                        />
                    </label>
                    <button onClick={this.handleSubmit} className="row">
                        Get Employees
                </button>
                </form>
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Contract Type Name</th>
                            <th>Role Id</th>
                            <th>Role Name</th>
                            <th>Role Description</th>
                            <th>Hourly Salary</th>
                            <th>Monthly Salary</th>
                            <th>Anual Salary</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.employees.map(employee =>
                            <tr key={employee.id}>
                                <td>{employee.id}</td>
                                <td>{employee.name}</td>
                                <td>{employee.contractTypeName}</td>
                                <td>{employee.roleId}</td>
                                <td>{employee.roleName}</td>
                                <td>{employee.roleDescription}</td>
                                <td>{employee.hourlySalary}</td>
                                <td>{employee.monthlySalary}</td>
                                <td>{employee.anualSalary}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }
}