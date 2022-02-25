import React from 'react';
import './App.css';
import {ThemeContext, themes} from "./components/ThemeContext";
import Page from "./components/Page";

type AppState = {
    theme: string,
    toggleTheme: () => void;
}

class App extends React.Component<any, AppState> {
    constructor(props: any) {
        super(props);

        this.toggleTheme = this.toggleTheme.bind(this);
        
        this.state = {
            theme: themes.light,
            toggleTheme: this.toggleTheme
        };
    }

    toggleTheme() {
        const newTheme = this.state.theme === themes.dark
            ? themes.light
            : themes.dark;

        this.setState({theme: newTheme});
    };
    
    render() {
        return (
            <ThemeContext.Provider value={this.state}>
                <Page/>
            </ThemeContext.Provider>
        );   
    }
}

App.contextType = ThemeContext;

export default App;
