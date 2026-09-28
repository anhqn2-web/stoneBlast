using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int columns = 8;
    public int rows = 8;
    public GameObject cellPrefab;
    public float spacing = 1.1f; // Khoảng cách giữa các tâm ô lưới

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Tính toán điểm bắt đầu để toàn bộ lưới được căn giữa
        float startX = -(columns * spacing) / 2f + (spacing / 2f);
        float startY = -(rows * spacing) / 2f + (spacing / 2f);

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector2 position = new Vector2(startX + (x * spacing), startY + (y * spacing));
                GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity);
                
                // Đặt ô lưới làm con của đối tượng chứa script này để dễ quản lý
                cell.transform.SetParent(this.transform);
                cell.name = $"Cell {x}-{y}";
            }
        }
    }
}