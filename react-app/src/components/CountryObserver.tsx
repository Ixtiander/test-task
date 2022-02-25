import React from "react";
import {getCities, getCountries} from "../services/DataService";
import DataItemModel from "../models/DataItemModel";
import {ThemeContext} from "./ThemeContext";
import classNames from "classnames";
import {AsyncPaginate, LoadOptions} from "react-select-async-paginate";

type CountryObserverState = {
    selectedCountry: any | null,
    selectedCity: any | null
}

class CountryObserver extends React.Component<any, CountryObserverState> {
    constructor(props:any) {
        super(props);

        this.state = {selectedCountry: null,  selectedCity: null};
        this.countySelected = this.countySelected.bind(this);
        this.citySelected = this.citySelected.bind(this);
        this.loadCountries = this.loadCountries.bind(this);
        this.loadCities = this.loadCities.bind(this);
    }
    
    async loadCountries() : Promise<any> {
        const countries = await getCountries();
        return {
            options: this.getSelectOptions(countries),
            hasMore: false,
        };
    }

    async loadCities(search: string, loadedOptions: any) : Promise<any> {
        const citiesResponse = await getCities(this.state.selectedCountry.value, search, loadedOptions.length);
        return {
            options: this.getSelectOptions(citiesResponse.items),
            hasMore: citiesResponse.hasMore,
        };
    }
    
    async countySelected(item: any) : Promise<void> {
        this.setState({selectedCountry: item, selectedCity: null});
    }

    citySelected(item: any) {
        this.setState({selectedCity: item});
    }

    getSelectOptions(elements: DataItemModel[] | null) {
        if(elements == null) {
            return [];
        }
        else {
            return elements.map((el) => {
                return {
                    label: el.name,
                    value: el.id
                };
            });
        }
    }
    
    render() {
        const cxt = this.context;
        function renderBlock(title: string, selectedEl: any | null, onChange: (item: any) => void, loadOptions: LoadOptions<any, any, any>) {
            return <div className="content">
                <p className={classNames(cxt.theme, "text")}>
                    {title}
                </p>
                <AsyncPaginate
                    className={classNames(cxt.theme, "select")}
                    onChange={onChange}
                    value={selectedEl}
                    inputValue={""}
                    placeholder={"Select..."}
                    loadOptions={loadOptions}
                />
            </div>;
        }

        return (
            <div>
                {renderBlock('Choose a country', this.state.selectedCountry, this.countySelected, this.loadCountries)}
                {this.state.selectedCountry && renderBlock('Choose a city', this.state.selectedCity, this.citySelected, this.loadCities)}
            </div>
        );
    }
}

CountryObserver.contextType = ThemeContext;

export default CountryObserver;
