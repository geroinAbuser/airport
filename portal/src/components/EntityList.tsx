import React, {JSX} from "react";

interface EntityListProps<T> {
    items: T[];
    renderItem: (item: T) => JSX.Element;
}

const EntityList = <T,>({ items, renderItem }: EntityListProps<T>) => {
    return (
        <div>
            {items.length > 0 ? (
                items.map((item, index) => <React.Fragment key={index}>{renderItem(item)}</React.Fragment>)
            ) : (
                <p>No items available.</p>
            )}
        </div>
    );
};

export default EntityList;
