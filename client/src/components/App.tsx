import React from 'react';
import { Login } from './Login';

type AppProps = {
    isLoggedIn: boolean;
};
type AppState = {};

export class App extends React.Component<AppProps, AppState> {
    render() {
        if (!this.props.isLoggedIn) {
            return <Login></Login>
        }
        else {
            return <div>LOGGED IN!</div>
        }        
    }
}

// interface AppProps {
//   name: string;
// }

// type ContainerProps = {
//   padding?: string | 0;
//   margin?: string | 0;
// };

// export const Container = styled.div<ContainerProps>`
//   padding: ${props => ('padding' in props ? props.padding : '0')};
//   margin: ${props => ('margin' in props ? props.margin : 0)};
// `;

// export default function App({ name }: AppProps) {
//   return <Container padding="100px">Hello {name}!</Container>;
// }
