using System;
using UnityEngine;

public class MyList<T>
{
    private T[] arr;                        // 실제 데이터 저장 배열
    private const int GROWTH_FACTOR = 2;    // 배열이 꽉차면 몇 배로 늘릴지
    public int Count { get; private set; }  // 배열의 원소 갯수

    // 배열의 전체 크기 (저장된 데이터 개수 X, 배열의 길이 O)
    public int Capacity
    {
        get { return arr.Length; }
    }

    // 생성자. 크기는 기본적으로 16으로 시작
    public MyList(int capacity = 16)
    {
        arr = new T[capacity];
        Count = 0;
    }

    // 원소 추가 메서드
    public void Add(T element)
    {
        // 배열이 꽉 찼을 경우 배열을 확장
        if (Count >= Capacity)
        {
            // 새로운 배열 크기는 기존 크기의 GROWTH_FACTOR 배수
            int newSize = Capacity * GROWTH_FACTOR;

            // 임시 배열 생성
            T[] temp = new T[newSize];

            // 기존 배열 데이터를 새 배열로 복사
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }

            // 기존 배열을 새 배열로 교체
            arr = temp;
        }

        // Count 위치에 새 원소 추가
        arr[Count] = element;

        // 원소 개수 증가
        Count++;
    }

    // 인덱스를 통해 원소를 가져오는 메서드
    public T Get(int index)
    {
        // 존재하지 않는 인덱스 접근 시 예외 처리
        if (index > Capacity - 1)
        {
            throw new Exception($"{index} 인덱스에 원소가 존재하지 않습니다.");
        }

        return arr[index];
    }
}
