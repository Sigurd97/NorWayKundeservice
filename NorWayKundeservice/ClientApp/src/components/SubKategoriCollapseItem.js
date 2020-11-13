import React, { Component } from 'react';
import { Collapse } from 'reactstrap';
import { IoIosArrowDown, IoIosArrowUp } from 'react-icons/io';
import { FAQCollapseItem } from './FAQCollapseItem';

export class SubKategoriCollapseItem extends Component {
    constructor(props) {
        super(props);

        this.toggleCollapse = this.toggleCollapse.bind(this);
        this.state = {
            collapse: false,
            faqs: [],
            SubKategoriId: this.props.SubKategori.id
        };
    }

    async toggleCollapse() {
        if (!this.state.collapse) {
            const response = await fetch('api/kundeservice/faqs?SubKategoriId=' + this.state.SubKategoriId);
            const faqs = await response.json();
            this.setState({ faqs: faqs });
        }
        this.setState({ collapse: !this.state.collapse });
    }

    render() {
        const SubKategori = this.props.SubKategori;
        let arrow = this.state.collapse ? <IoIosArrowUp className="arrow" /> : <IoIosArrowDown className="arrow" />;

        return (
            <div>
                <h2 onClick={this.toggleCollapse}>
                    <strong>{SubKategori.navn} {arrow} </strong>
                    <hr></hr>
                </h2>
                <Collapse isOpen={this.state.collapse}>
                    {this.state.faqs.map(faq =>
                        <FAQCollapseItem key={faq.id} faq={faq} />
                    )}
                </Collapse>
            </div>
        );
    }
}