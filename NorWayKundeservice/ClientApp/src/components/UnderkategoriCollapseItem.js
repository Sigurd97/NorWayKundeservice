import React, { Component } from 'react';
import { Collapse } from 'reactstrap';
import { IoIosArrowDown, IoIosArrowUp } from 'react-icons/io';
import { FAQCollapseItem } from './FAQCollapseItem';

export class UnderkategoriCollapseItem extends Component {
    constructor(props) {
        super(props);

        this.toggleCollapse = this.toggleCollapse.bind(this);
        this.state = {
            collapse: false,
            faqs: [],
            underkategoriId: this.props.underkategori.id
        };
    }

    async toggleCollapse() {
        if (!this.state.collapse) {
            const response = await fetch('api/kundeservice/faqs?underkategoriId=' + this.state.underkategoriId);
            const faqs = await response.json();
            this.setState({ faqs: faqs });
        }
        this.setState({ collapse: !this.state.collapse });
    }

    render() {
        const underkategori = this.props.underkategori;
        let arrow = this.state.collapse ? <IoIosArrowUp className="arrow" /> : <IoIosArrowDown className="arrow" />;

        return (
            <div>
                <h2 onClick={this.toggleCollapse}>
                    <strong>{underkategori.navn} {arrow} </strong>
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