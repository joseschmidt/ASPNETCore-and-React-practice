

class APIResult extends React.Component {

    /**
     * React Class Constructor
     */
    constructor(props) {
        super(props);
        this.state = {
            result: "loading..."
        };
    }

    /**
     * Consuming api with fetch method
     */
    fetchResult() {
        fetch("/api/example/", { method: "GET" })
            .then((result) => result.json())
            .then((items) => this.setState({ result: items }));
    }

    /**
     * Component"s render
     */
    render() {
        return (
            <div>
                <button onClick={() => this.fetchResult()}>
                    {this.props.text}
                </button>
                <div>
                    <label>{this.state.result}</label>
                </div>
            </div>
        );
    }
}

/**
 * Main component
 */
var CommentBox = React.createClass({
    render() {
        return (
            <div className="commentBox">
                Hello, world!.
                <div>
                    <p>Let"s consume a API?</p>
                    <APIResult text="Now!" />
                </div>
            </div>
        );
    }
});

ReactDOM.render(
    <CommentBox />,
    document.getElementById("content")
);

