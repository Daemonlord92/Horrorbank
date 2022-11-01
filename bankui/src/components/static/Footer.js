export default function Footer() {
    const currentYear = new Date().getFullYear();

    return(
        <footer className="d-flex flex-wrap justify-content-between align-items-center py-3 my-4 border-top fixed-bottom">
            <div className="col-md-12 d-flex text-center">
                <div className="col-md-4"/>
                <span className="mb-3 mb-md-0 text-danger col-md-4">© {currentYear} Horrorbank, Inc</span>
                <div className="col-md-4"/>
            </div>
        </footer>
    )
}