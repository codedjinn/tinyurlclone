import React from "react";
import { Button, FormControl } from 'react-bootstrap';

const inputStyle = {
    marginTop: "10px"
};

type LoginState = {
    name:string;
    email:string;
};

export class Login extends React.Component<{}, LoginState> {

    constructor(props:any) {
        super(props);
        this.state = { name: "", email: "" };
    }
    
    onSignInClick(e: any): void {
        e.preventDefault();

        if (this.state.name === "" || this.state.email === "") {
            //
            return;
        }

        
    }

    render() {
        return <div className="login-cntr">
            <div className="login-header-box drop-shadow">
                <div className="login-header-title">Login</div>

                <FormControl
                    placeholder="Name"
                    aria-label="Name"
                    style={inputStyle}
                    value={this.state.name}
                    onChange={e => this.setState({ name: e.target.value })}
                    />

                <FormControl
                    placeholder="Email"
                    aria-label="Email"
                    style={inputStyle}
                    value={this.state.email}
                    onChange={e => this.setState({ email: e.target.value })}
                    />

                <Button style={inputStyle}
                        onClick={(e) => this.onSignInClick(e)}
                        >Sign-In</Button>
            </div>
        </div>
    }

}