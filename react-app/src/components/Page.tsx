import React from "react";
import classNames from "classnames";
import CountryObserver from "./CountryObserver";
import {ThemeContext} from "./ThemeContext";

class Page extends React.Component {
    render() {
        return <div className={classNames(this.context.theme, 'app')}>
            <header className="app-header">
                <ThemeContext.Consumer>
                    {({toggleTheme}) => (
                        <button onClick={toggleTheme}>Change theme</button>
                    )}
                </ThemeContext.Consumer>
                <CountryObserver/>
            </header>
        </div>
    }
}

Page.contextType = ThemeContext;

export default Page;