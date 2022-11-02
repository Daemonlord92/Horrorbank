export default function Footer() {
    const currentYear = new Date().getFullYear();

    return(
        <footer className="d-flex flex-wrap py-2 border-top fixed-bottom bg-dark">
            <div className="col-md-12 d-flex text-center footer">
                <div className="col-md-4"/>
                <span className="mb-3 mb-md-0 text-danger col-md-4">© {currentYear} Horrorbank. Inc</span>
                <div className="col-md-4"/>
            </div>
        </footer>
    )
}