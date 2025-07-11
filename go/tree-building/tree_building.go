package tree

import (
	"errors"
	"fmt"
	"slices"
	"sort"
)

type TreeMap map[int][]int

func (t TreeMap) GetParentIDs() (keys []int) {
	for k := range t {
		keys = append(keys, k)
	}
	return
}

// GetChildrenIDs returns a slice of childrens ID's withen a parent.
func (t TreeMap) GetChildrenIDs(parentID int) (children []int) {
	return t[parentID]
}

func (t TreeMap) NextNodeIsChild(parentID int) bool {
	return slices.Contains[[]int, int](t[parentID], parentID+1)
}

func NewTreeMap(records []Record) TreeMap {
	depth := Depth(records)
	treeMap := make(TreeMap, depth)
	for d := 0; d <= depth; d++ {
		for _, r := range records {
			if r.Parent == d {
				treeMap[d] = append(treeMap[d], r.ID)
			}
		}
		sort.Ints(treeMap[d])
	}
	return treeMap
}

type Record struct {
	ID     int
	Parent int
	// feel free to add fields as you see fit
}

func RecordErrors(records []Record) error {
	treeMap := NewTreeMap(records)
	var hasRootNode int

	//if !reflect.DeepEqual(treeMap.GetParentIDs(), treeMap.GetChildrenIDs(0)) && len(treeMap) > 1 {
	//	fmt.Println(treeMap)
	//	return errors.New("cycle directly/indirectly")
	//}

	for _, pid := range treeMap.GetParentIDs() {
		if pid > 0 {
			for _, cid := range treeMap.GetChildrenIDs(pid) {
				if cid == pid {
					return errors.New("cycle directly")
				}
				if cid < pid {
					return errors.New("cycle indirectly")
				}
			}
		}
	}

	var allIDs []int
	for _, r := range records {
		if r.ID == 0 {
			hasRootNode++
		}

		if r.ID < r.Parent {
			return errors.New("higher id parent of lower id")
		}

		if r.ID == 0 && r.Parent > 0 {
			return errors.New("root node has parent")
		}

		allIDs = append(allIDs, r.ID)
	}

	if hasRootNode == 0 && len(records) != 0 {
		return errors.New("no root node")
	}

	if hasRootNode > 1 {
		return errors.New("duplicate root node")
	}

	// The last index of the slice should be equal to the length of the slice + 1 if the numbers
	// are continuous.
	if len(allIDs) > 0 {
		sort.Ints(allIDs)
		if allIDs[len(allIDs)-1] != len(allIDs)-1 {
			return errors.New("non-continuous")
		}
	}

	for _, v := range treeMap {
		if len(v) != len(slices.Compact(v)) {
			return errors.New("duplicate nodes found")
		}
	}

	return nil

}

type Node struct {
	ID       int
	Children []*Node
	// feel free to add fields as you see fit
}

func Depth(records []Record) (depth int) {
	for _, r := range records {
		if r.Parent > depth {
			depth = r.Parent
		}
	}
	return
}

func ConvertChildrenToNode(chilren []int) []*Node {
	n := []*Node{}
	for _, c := range chilren {
		if c != 0 {
			n = append(n, &Node{ID: c})
		}
	}
	return n
}

func Build(records []Record) (*Node, error) {
	err := RecordErrors(records)
	if err != nil {
		return nil, err
	}

	treeMap := NewTreeMap(records)
	if len(treeMap) < 1 {
		return nil, nil
	}

	root := &Node{}
	fmt.Println(treeMap)

	for t := 0; t < len(treeMap); t++ {
		n := &Node{}

		if len(treeMap) == 1 {
			root.Children = ConvertChildrenToNode(treeMap[t])
		}

		if t > 0 && !treeMap.NextNodeIsChild(t) {
			fmt.Println(t)
			n.ID = t
			n.Children = ConvertChildrenToNode(treeMap[t])
			fmt.Println("root:", root)
			root.Children = append(root.Children, n)
		}

		if treeMap.NextNodeIsChild(t) {
			n.ID = t
			n.Children = append(n.Children, ConvertChildrenToNode(treeMap[t])...)
		}
	}

	return root, nil
}
